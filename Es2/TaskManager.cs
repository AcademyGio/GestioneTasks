using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Es2
{
    enum Livello
    {
        Basso,
        Medio,
        Alto,
        Tutti
    }

    class TaskManager
    {
        int _id;    // progressivo da attribuire a ogni task creato
        Dictionary<int, Task> _tasks = new Dictionary<int, Task>();
        public Task CreaTask(string descrizione, DateTime dataScadenza, Livello livello)
        {
            Task t = new Task(++_id, descrizione, dataScadenza, livello);

            _tasks[t.ID] = t;

            return t;
        }

        public bool EsisteTask(int id)
        {
            return _tasks.ContainsKey(id);
        }

        public void EliminaTask(int id)
        {
            _tasks.Remove(id);
        }

        public string OttieniElenco(Livello livello, Formato formato)
        {
            string s = "";

            foreach (Task t in _tasks.Values)
                if (livello == Livello.Tutti || t.Livello == livello)
                    s += t.OttieniDati(formato) + '\n';

            return s;
        }
    }
}
