using System;
using System.Collections.Generic;
using System.Text;
using GenericUndoRedo;
using ShapeLib;

namespace UndoRedoByActionDemo
{
    abstract class ShapeMemento : IMemento<ShapePool>
    {
        #region IMemento<ShapePool> Members

        public abstract IMemento<ShapePool> Restore(ShapePool target);
        
        #endregion
    }
    
    class InsertShapeMemento : ShapeMemento
    {
        private int index;
        public InsertShapeMemento(int index)
        {
            this.index = index;
        }

        public override IMemento<ShapePool> Restore(ShapePool target)
        {
            Shape removed = target[index];
            IMemento<ShapePool> inverse = new RemoveShapeMemento(index, removed);
            target.RemoveAt(index);
            return inverse;
        }
    }
    
    class RemoveShapeMemento : ShapeMemento
    {
        Shape removed;
        int index;
        public RemoveShapeMemento(int index, Shape removed)
        {
            this.index = index;
            this.removed = removed;
        }

        public override IMemento<ShapePool> Restore(ShapePool target)
        {
            IMemento<ShapePool> inverse = new InsertShapeMemento(index);
            target.Insert(index, removed);
            return inverse;
        }
    }

    class AddShapeMemento : ShapeMemento
    {
        public AddShapeMemento()
        {
        }

        public override IMemento<ShapePool> Restore(ShapePool target)
        {
            int index = target.Count - 1;
            IMemento<ShapePool> inverse = new RemoveShapeMemento(index, target[index]);
            target.RemoveAt(target.Count - 1);
            return inverse;
        }
    }
}
