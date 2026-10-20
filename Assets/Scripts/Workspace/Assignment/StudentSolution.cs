using System;
using System.Collections.Generic;

namespace Assignment
{
    public class StudentSolution
    {
        class Action
        {
            public string Name;
            public int Value;
        }

        #region Lecture

        public (int Count, int Popped, int Peek, int CountAfterPeek) LCT01_StackSyntax()
        {
            Stack<int> stack = new Stack<int>();

            // 1. Push 1, 2, 3 ตามลำดับ
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            // 2. เก็บ Count ก่อน Pop
            int count = stack.Count;

            // 3. Pop และเก็บค่าที่นำออก
            int popped = stack.Pop();

            // 4. Peek และเก็บค่าบนสุด รวมถึง Count หลัง Peek
            int peek = stack.Peek();
            int countAfterPeek = stack.Count;

            return (count, popped, peek, countAfterPeek);
        }

        public (int Count, int Dequeued, int Peek, int CountAfterPeek) LCT02_QueueSyntax()
        {
            Queue<int> queue = new Queue<int>();

            // 1. Enqueue 1, 2, 3 ตามลำดับ
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            // 2. เก็บ Count ก่อน Dequeue
            int count = queue.Count;

            // 3. Dequeue และเก็บค่าที่นำออก
            int dequeued = queue.Dequeue();

            // 4. Peek และเก็บค่าหน้า รวมถึง Count หลัง Peek
            int peek = queue.Peek();
            int countAfterPeek = queue.Count;

            return (count, dequeued, peek, countAfterPeek);
        }

        public string[] LCT03_ActionStack()
        {
            Action action1 = new Action { Name = "Action 1" };
            Action action2 = new Action { Name = "Action 2" };
            Action action3 = new Action { Name = "Action 3" };

            Stack<Action> actionStack = new Stack<Action>();

            // Push เข้า Stack (LIFO)
            actionStack.Push(action1);
            actionStack.Push(action2);
            actionStack.Push(action3);

            List<string> result = new List<string>();

            // Pop จน Stack ว่าง
            while (actionStack.Count > 0)
            {
                result.Add(actionStack.Pop().Name);
            }

            return result.ToArray();
        }

        public string[] LCT04_ActionQueue()
        {
            Action action1 = new Action { Name = "Action 1" };
            Action action2 = new Action { Name = "Action 2" };
            Action action3 = new Action { Name = "Action 3" };

            Queue<Action> actionQueue = new Queue<Action>();

            // Enqueue เข้า Queue (FIFO)
            actionQueue.Enqueue(action1);
            actionQueue.Enqueue(action2);
            actionQueue.Enqueue(action3);

            List<string> result = new List<string>();

            // Dequeue จน Queue ว่าง
            while (actionQueue.Count > 0)
            {
                result.Add(actionQueue.Dequeue().Name);
            }

            return result.ToArray();
        }

        #endregion

        #region Assignment

        public string ASN01_ReverseString(string str)
        {
            Stack<char> stack = new Stack<char>();

            // Push ทุกตัวอักษรเข้า Stack
            foreach (char c in str)
            {
                stack.Push(c);
            }

            // Pop ออกมาเพื่อกลับลำดับอักขระ
            char[] reversedChars = new char[str.Length];
            int index = 0;
            while (stack.Count > 0)
            {
                reversedChars[index++] = stack.Pop();
            }

            return new string(reversedChars);
        }

        public bool ASN02_StackPalindrome(string str)
        {
            // Reverse string ด้วย Stack
            string reversed = ASN01_ReverseString(str);

            // เปรียบเทียบ string ต้นฉบับกับ reversed string
            return str.Equals(reversed);
        }

        #endregion

        #region Extra

        public bool EX01_ParenthesesChecker(string str)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char c in str)
            {
                // ถ้าเป็น opening bracket ให้ Push เข้า Stack
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                // ถ้าเป็น closing bracket
                else if (c == ')' || c == ']' || c == '}')
                {
                    // เจอ closing bracket แต่ไม่มี opening ใน Stack
                    if (stack.Count == 0) return false;

                    char top = stack.Pop();

                    // ตรวจสอบว่าคู่วงเล็บตรงกันหรือไม่
                    if ((c == ')' && top != '(') ||
                        (c == ']' && top != '[') ||
                        (c == '}' && top != '{'))
                    {
                        return false;
                    }
                }
            }

            // ต้องไม่มี opening bracket เหลือค้างใน Stack
            return stack.Count == 0;
        }

        #endregion
    }
}