using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

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

        public void SetCurrent(FlightPlanList current)
        {
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
            data = data.Remove(data.Length - 1);
            return data;
        }

        public void Dump(string nombre)
        {
            StreamWriter W = new StreamWriter(nombre);
            W.Write(this.DumpString());
            W.Close();
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

        public string
        GenerateFligthReport(string filename, string id, double pV, double nV)
        {
            StreamReader R = new StreamReader(filename);
            string text = R.ReadToEnd();
            R.Close();
            text = text.Replace("[[FN]]", id);
            text = text.Replace("[[PV]]", Convert.ToString(pV));
            text = text.Replace("[[NV]]", Convert.ToString(nV));

            return text;
        }

        public string
        GenerateCompanyReport(string filename, string icao, string flreport, DataRow company)
        {
            StreamReader R = new StreamReader(filename);
            string text = R.ReadToEnd();
            R.Close();
            text = text.Replace("[[Nombre]]", Convert.ToString(company["nombre"]));
            text = text.Replace("[[email]]", Convert.ToString(company["email"]));
            text = text.Replace("[[phone]]", Convert.ToString(company["telefono"]));
            text = text.Replace("[[vuelos]]", flreport);
            return text;
        }

        public string GenerateReport(DataTable data)
        {
            Dictionary<string, string> repdict =
                new Dictionary<string, string>();
            for (int i = 0; i < current.GetLen(); i++)
            {
                FlightPlan pfligth = history.Peek().GetFlightAtIndex(i);
                FlightPlan cfligth = current.GetFlightAtIndex(i);
                if (pfligth.GetVelocidad() != cfligth.GetVelocidad())
                {
                    if (repdict.ContainsKey(cfligth.GetCompany()))
                    {
                        repdict[cfligth.GetCompany()] +=
                            GenerateFligthReport("templates\\vuelos.html",
                            cfligth.GetId(),
                            pfligth.GetVelocidad(),
                            cfligth.GetVelocidad());
                    }
                    else
                    {
                        repdict[cfligth.GetCompany()] =
                            GenerateFligthReport("templates\\vuelos.html",
                            cfligth.GetId(),
                            pfligth.GetVelocidad(),
                            cfligth.GetVelocidad());
                    }
                }
            }
            string crtext = "";
            for (int i = 0; i < data.Rows.Count; i++)
            {
                string key = Convert.ToString(data.Rows[i]["icao"]);
                if (repdict.ContainsKey(key))
                {
                    crtext += GenerateCompanyReport("templates\\compañia.html", key, repdict[key], data.Rows[i]);
                }
            }
            StreamReader R = new StreamReader("templates\\main.html");
            string text = R.ReadToEnd();
            R.Close();
            text = text.Replace("[[CompRep]]", crtext);
            return text;
        }
        public void SaveState()
        {
            this.history.Push(current.Copy());
            this.current = this.current.Copy();
        }
    }
}
