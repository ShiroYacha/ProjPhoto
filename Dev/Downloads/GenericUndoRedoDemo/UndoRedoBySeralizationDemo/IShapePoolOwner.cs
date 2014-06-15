using System;
using System.Collections.Generic;
using System.Text;
using ShapeLib;

namespace UndoRedoBySeralizationDemo
{
    interface IShapePoolOwner
    {
        ShapePool ShapePool
        {
            get;
            set;
        }
    }
}
