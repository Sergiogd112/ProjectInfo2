using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FlightLib
{
    public class State
    {
        Stack<FlightPlanList> history;

        FlightPlanList current;

        public State(Stack<FlightPlanList> history, FlightPlanList current)
        {
            this.history = history;
            this.current = current;
        }

        public State()
        {
            this.history = new Stack<FlightPlanList>();
            this.current = new FlightPlanList();
        }

        public FlightPlanList GetCurrentList()
        {
            return current;
        }

        public int GetLen()
        {
            return history.Count;
        }
        public void SetCurrent(FlightPlanList current){
            this.current = current;
        }
        public void AddState(FlightPlanList list)
        {
            if (history.Count == 0 && current.GetLen() == 0)
            {
                this.current = list;
            }
            else
            {

                history.Push(this.current.Copy());
                this.current = list;
            }




        }

        public void Move(int cicles)
        {
            // añadimos el estado actual al historial de esta
            this.history.Push(current.Copy());
            this.current = this.current.Copy();
            this.current.MoveAll(cicles);
        }

        public bool Deshacer()
        {
            if (this.history.Count == 0)
            {
                return false;
            }
            else
            {
                this.current = this.history.Pop();
                return true;
            }
        }
        public void Restart()
        {
            while (1 < this.history.Count)
            {
                this.history.Pop();
            }
            this.current = this.history.Pop();
        }
        public String DumpString()
        {
            String data = this.current.DumpString() + "\n";
            foreach (FlightPlanList list in this.history)
            {
                data += list.DumpString() + "\n";
            }
            return data;
        }
        public void Dump(string nombre)
        {
            StreamWriter W = new StreamWriter(nombre);
            W.WriteLine(this.DumpString());
        }
        public static State Load(string file)
        {
            StreamReader R = new StreamReader(file);
            string text = R.ReadToEnd();
            return State.LoadString(text);
        }

        public static State LoadString(string s)
        {
            string[] data = s.Split('\n');
            State state = new State();
            foreach (string listString in data)
            {
                state.AddState(FlightPlanList.LoadString(listString));
            }
            return state;
        }
    }
}
