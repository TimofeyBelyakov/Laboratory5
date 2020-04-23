using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            ShapeField field = new ShapeField();

            field.setShape(12, 23, "Круг", ConsoleColor.Blue, "");
            field.setShape(100, 200, "Квадрат", ConsoleColor.Cyan, "");
            field.setShape(0, 0, "Прямоугольник", ConsoleColor.Green, "");
            field.setShape(-34, -17, "Треугольник", ConsoleColor.Red, "");
            field.setShape(-23, -8, "Овал", ConsoleColor.Yellow, "");
            field.setShape(-22, -4, "Овал", ConsoleColor.Black, "");
            field.setShape(0, 100, "Прямоугольник", ConsoleColor.DarkRed, "");

            field.DrawShapes();

            Console.ReadKey();
        }
    }

    /// <summary>
    ///     Класс, описывающий тип фигуры.
    ///     Содержит в себе метод вывода фигуры на экран в определённых координатах.
    /// </summary>
    /// 
    class ShapeType
    {
        public string name;
        public ConsoleColor color;
        public string form;

        public ShapeType(string name, ConsoleColor color, string form)
        {
            this.name = name;
            this.color = color;
            this.form = form;
        }

        public void DrawShape(int x, int y)
        {
            Console.WriteLine("Фигура: " + name + ",\nЦвет: " + color + ",\nКоординаты: " + x + " и " + y + " - нарисована!\n");
        }
    }

    /// <summary>
    ///     Фабрика фигур, формирующая список типов фигур.
    ///     Содержит метод, возвращающий тип фигуры, если таковой есть в списке, и добавляющий таковой, если в списке его нет.
    /// </summary>
    /// 
    class ShapeFactory
    {
        public static List<ShapeType> types = new List<ShapeType>();

        public static ShapeType getShapeType(string name, ConsoleColor color, string form)
        {
            ShapeType type = new ShapeType(name, color, form);
            bool flag = false;

            foreach (ShapeType elem in types)
            {
                if (type == elem) flag = true;
            }

            if (!flag) types.Add(type);

            return type;
        }
    }

    /// <summary>
    ///     Класс, описывающий фигуру.
    ///     Содержит в себе метод вывода фигуры на экран в определённых координатах.
    /// </summary>
    /// 
    class Shape
    {
        public int x;
        public int y;
        public ShapeType type;

        public Shape(int x, int y, ShapeType type)
        {
            this.x = x;
            this.y = y;
            this.type = type;
        }

        public void DrawShape()
        {
            type.DrawShape(x, y);
        }
    }

    /// <summary>
    ///     Класс, описывающий полотно фигур на экране.
    ///     Содержит в себе экземпляры всех выводимых фигур.
    /// </summary>
    /// 
    class ShapeField
    {
        public List<Shape> shapes = new List<Shape>();
        private ShapeType type;
        private Shape shape;

        public void setShape(int x, int y, string name, ConsoleColor color, string form)
        {
            type = ShapeFactory.getShapeType(name, color, form);
            shape = new Shape(x, y, type);
            shapes.Add(shape);
        }

        public void DrawShapes()
        {
            foreach(Shape elem in shapes)
            {
                elem.DrawShape();
            }
        }

        public void ClearShapes()
        {
            shapes.Clear();
        }
    }
}
