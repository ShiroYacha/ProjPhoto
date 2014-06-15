using System;
using System.Collections.Generic;
using System.Text;
using GenericUndoRedo;
using ShapeLib;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace UndoRedoBySeralizationDemo
{

    class ShapePoolMemento : IMemento<IShapePoolOwner>
    {
        MemoryStream stream;

        public ShapePoolMemento(ShapePool pool)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, pool);
            ms.Seek(0, SeekOrigin.Begin);
            stream = ms; 
        }

        #region IMemento<IShapePoolOwner> Members

        public IMemento<IShapePoolOwner> Restore(IShapePoolOwner target)
        {
            IMemento<IShapePoolOwner> inverse = new ShapePoolMemento(target.ShapePool);

            BinaryFormatter bf = new BinaryFormatter();
            ShapePool p = bf.Deserialize(stream) as ShapePool;
            target.ShapePool = p;
            return inverse;
        }

        #endregion
    }
}
