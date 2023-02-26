using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            
            ModifiedState modifİed = new ModifiedState();
            modifİed.DoAction(context);
            
            DeletedState deleted = new DeletedState();
            deleted.DoAction(context);

            Console.WriteLine(context.GetState().ToString());

            AddedState added = new AddedState();
            added.DoAction(context);
            Console.ReadLine();
        }
    }
    public interface IState
    {
        void DoAction(Context context);

    }
    class ModifiedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State : Modify");
            context.SetState(this);
        }
        public override string ToString()
        {
            return "Modified";
        }
    }
    class DeletedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State : Deleted");
            context.SetState(this);
        }
        public override string ToString()
        {
            return "Deleted";
        }
    }
    class AddedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State : Added");
            context.SetState(this);
        }
        public override string ToString()
        {
            return "Added";
        }
    }
}
