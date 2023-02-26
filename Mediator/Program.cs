using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();
            Teacher engin = new Teacher(mediator);
            Student enes = new Student(mediator);
            enes.Name = "Enes";
            Student kamil = new Student(mediator);
            kamil.Name = "Kamil";
            engin.Name = "Engin";
            mediator.Teacher = engin;
            mediator.Students = new List<Student> { enes, kamil };
            engin.SenNewImage("slide.png");
            engin.RecieveQuestion("is it true?", enes);
            Console.ReadLine();
        }

    }
    abstract class CourseMember
    {
        protected Mediator Mediator;

        protected CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
    }
    class Teacher : CourseMember
    {
        public string Name { get; set; }
        public Teacher(Mediator mediator) : base(mediator)
        {

        }

        public void RecieveQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher recived a question from {0},{1}", student.Name, question);
        }
        public void SenNewImage(string url)
        {
            Console.WriteLine("Teacher change slide: {0}", url);
            Mediator.UpdateImage(url);
        }
        public void AnswerQuestion(string answer, Student student)
        {
            Console.WriteLine("Theacer answered question: {0},{1}", student.Name, answer);
        }
    }
    class Student : CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {
        }

        public string Name { get; set; }
        internal void RecieveImage(string url)
        {
            Console.WriteLine("Studet recive image : {0}", url);
        }

        internal void RecieveAnswer(string answer)
        {
            Console.WriteLine("Studen recived answer{0}", answer);
        }
    }
    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.RecieveImage(url);
            }
        }
        public void SenQuestion(string question, Student student)
        {
            Teacher.RecieveQuestion(question, student);
        }
        public void SendAnswer(string answer, Student student)
        {
            student.RecieveAnswer(answer);
        }
    }
}
