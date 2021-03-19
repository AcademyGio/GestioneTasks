using System;
using System.Collections.Generic;

namespace Es2
{
    enum Formato
    {
        Plain,
        CSV
    }

    class Task
    {
        public int ID { get; }
        public string Descrizione { get; }
        public DateTime DataScadenza { get; }
        public Livello Livello { get; }

        public Task(int id, string descrizione, DateTime dataScadenza, Livello livello)
        {
            if (dataScadenza < DateTime.Today)
                throw new ArgumentOutOfRangeException();

            ID = id;
            Descrizione = descrizione;
            DataScadenza = dataScadenza;
            Livello = livello;
        }

        public string OttieniDati(Formato formato)
        {
            switch (formato)
            {
                case Formato.Plain:
                    return $"ID: {ID}, {Descrizione}, Scadenza: {DataScadenza.ToShortDateString()}, Livello: {Livello}";
                case Formato.CSV:
                    return $"{ID};{Descrizione};{DataScadenza.ToShortDateString()};{Livello}";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
