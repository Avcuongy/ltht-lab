using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

struct MyStruct
{
    public int X;
}

public class MyClass
{
    public int Value;
}

public class q3_1
{
    // static field -> reference nằm trong static area, object nằm trên HEAP
    public static MyClass staticObj = new MyClass { Value = 999 };

    public static void Solution()
    {
        int a = 10;  // value type -> STACK
        MyStruct s;
        s.X = 5;  // struct local -> STACK (bên trong stack frame của Main)

        MyClass obj1 = new MyClass { Value = 1 };
        // obj1 (reference) -> STACK
        // actual object -> HEAP

        CreateObject();

        Console.WriteLine(obj1.Value);
    }

    public static void CreateObject()
    {
        MyClass obj2 = new MyClass { Value = 2 };
        // obj2 reference -> STACK (frame của CreateObject)
        // object -> HEAP

        int local = 42;  // STACK
    }
}
