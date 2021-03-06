﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public interface IEnumerable
{
    //IEnumerable只有一个方法，返回可循环访问集合的枚举数。
    IEnumerator GetEnumerator();
}

public interface IEnumerator
{
    // 方法
    //移到集合的下一个元素。如果成功则返回为 true；如果超过集合结尾，则返回false。
    bool MoveNext();
    // 将集合设置为初始位置，该位置位于集合中第一个元素之前
    void Reset();

    // 属性：获取集合中的当前元素
    object Current { get; }
}

namespace IEnumberableTest
{   
    //一个结构体，用于类myEnum
    struct point
    {
        public int x;
        public int y;
        public int z;
    }

    //一个派生于IEnumerable和IEnumerator接口的自定义类
    class myEnum : IEnumerable, IEnumerator
    {
        //定义索引
        private int index;

        //定义一个point结构的数组
        private point[] points;

        //类的构造函数，用于初始化point结构数组
        public myEnum(int numofpoint)
        {
            this.index = -1;
            points = new point[numofpoint];

            for (int i = 0; i < points.Length; i++)
            {
                points[i].x = i;
                points[i].y = i * i;
                points[i].z = i * i * i;
            }
        }

        //实现IEnumerable接口的GetEnumerator方法，返回一个IEnumerator，这里返回我们的自定义类，因为要对这个类的对象进行迭代
        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        //实现IEnumerator接口的Reset方法，将集合索引置于第一个元素之前
        public void Reset()
        {
            index = -1;
        }

        //实现IEnumerator接口的Current属性，返回一个自定义的point结构，即point数组的第index元素
        public object Current
        {
            get
            {
                return points[index];
            }
        }

        //实现IEnumerator接口的MoveNext方法，用于向前访问集合元素，如果超出集合范围，返回false
        public bool MoveNext()
        {
            index++;
            return index >= points.Length ? false : true;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            myEnum enum1 = new myEnum(20);

            foreach (point p in enum1)
            {
                Console.WriteLine("(" + p.x.ToString() + "," + p.y.ToString() + "," + p.z.ToString() + ")");
            }

            Console.Read();
        }
    }

}



