using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilledEditor
{
    class Tabel
    {
        public Tabel()
        {
        }

        public Tabel(int id, string calnr, string dansknavn, string lokation, string etanr, string blisternr, string artikkelnr, string engelsknavn, string tysknavn, string fransknavn, string tekst)
        {
            this.ID = id;
            this.CalNr = calnr;
            this.DanskNavn = dansknavn;
            this.Lokation = lokation;
            this.Etanr = etanr;
            this.BlisterNr = blisternr;
            this.ArtikkelNr = artikkelnr;
            this.EngelskNavn = engelsknavn;
            this.TyskNavn = tysknavn;
            this.FranskNavn = fransknavn;
            this.Tekst = tekst;
        }

        public int ID { get; set; }
        public string CalNr { get; set; }
        public string DanskNavn { get; set; }
        public string Lokation { get; set; }
        public string Etanr { get; set; }
        public string BlisterNr { get; set; }
        public string ArtikkelNr { get; set; }
        public string EngelskNavn { get; set; }
        public string TyskNavn { get; set; }
        public string FranskNavn { get; set; }
        public string Tekst { get; set; }
    }
}

