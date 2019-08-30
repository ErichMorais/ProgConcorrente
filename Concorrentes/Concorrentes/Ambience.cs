using Concorrentes.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Concorrentes
{
    public partial class Ambience : Form
    {
        public const char FROG = 'f';
        public const char FLY = 'y';
        public const char SUGAR = 's';
        public const int  ADJUST = 25;

        public Semaphore s_mutex;

        Frog frog;
        Fly fly;
        Sugar sugar;
        Thread t;
        Controle controle;

        Random rnd = new Random();

        public int frogCont = 0;
        public int flyCont = 0;
        public int sugarCont = 0;
        public int calories = 0;
        public int tempo = 0;
        public Ambience amb;
        
        //public List<Thread> listaThread = new List<Thread>();
        //public List<Frog> listaFrog = new List<Frog>();
        //public List<Fly> listaFly = new List<Fly>();
        //public List<Sugar> listaSugar = new List<Sugar>();

        public List<Controle> listaControle = new List<Controle>();

        public Ambience()
        {

        }

        public Ambience(int nFrog, int nFly, int nSugar, int nCal)
        {
            frogCont = nFrog;
            flyCont = nFly;
            sugarCont = nSugar;
            calories = nCal;
            int x, y;
            
            s_mutex = new Semaphore(1, 1);

            InitializeComponent();

            for (int i = 0; i < flyCont; i++)
            {
                fly = new Fly();
                t = new Thread(fly.move);

                x = fly.picture.Location.X + 25;
                y = fly.picture.Location.Y + 25;

                controle = new Controle(x, y, FLY, listaControle);

                listaControle.Add(controle);

                fly.indexC = listaControle.IndexOf(controle);

                controle.positionC = listaControle.IndexOf(controle);
                controle.fly = fly;
                controle.frog = null;
                controle.sugar = null;
                controle.thread = t;

                fly.s_mutex = s_mutex;
                
                fly.calories = calories;
                fly.CalMax = calories;
                fly.listaControle = listaControle;

                Thread.Sleep(40);
            }
            
            for (int i = 0; i < frogCont; i++)
            {
                frog = new Frog();
                t = new Thread(frog.move);

                x = frog.picture.Location.X + 25;
                y = frog.picture.Location.Y + 25;

                controle = new Controle(x, y, FROG, listaControle);

                listaControle.Add(controle);

                frog.indexC = listaControle.IndexOf(controle);

                controle.positionC = listaControle.IndexOf(controle);
                controle.fly = null;
                controle.frog = frog;
                controle.sugar = null;
                controle.thread = t;

                frog.s_mutex = s_mutex;
                frog.calories = calories;
                frog.CalMax = calories;
                frog.listaControle = listaControle;

                Thread.Sleep(40);
            }

            for (int i = 0; i < sugarCont; i++)
            {
                sugar = new Sugar();

                x = sugar.picture.Location.X + 25;
                y = sugar.picture.Location.Y + 25;

                controle = new Controle(x, y, SUGAR, listaControle);

                listaControle.Add(controle);

                sugar.indexC = listaControle.IndexOf(controle);

                controle.positionC = listaControle.IndexOf(controle);
                controle.fly = null;
                controle.frog = null;
                controle.sugar = sugar;
                controle.thread = null;

                Thread.Sleep(40);
            }
        }

        private void Ambience_Load(object sender, EventArgs e)
        {
            foreach (Controle aux in listaControle)
            {
                if(aux.sugar != null)
                    Controls.Add(aux.sugar.picture);
                else
                {
                    if (aux.fly != null)
                        Controls.Add(aux.fly.picture);
                    else if (aux.frog != null)
                        Controls.Add(aux.frog.picture);

                    aux.thread.Start();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (fly != null) { if (fly.flagFly == true) newFly(); }
            att();
            labelFrog.Text = "Sapos: " + frogCont;
            labelFly.Text = "Moscas: " + flyCont;
            labelSugar.Text = "Açucar: " + sugarCont;
            if (tempo%rnd.Next(3,5) == 0)
            {
                sugar = new Sugar();

                int x = sugar.picture.Location.X + 25;
                int y = sugar.picture.Location.Y + 25;

                controle = new Controle(x, y, SUGAR, listaControle);

                listaControle.Add(controle);

                sugar.indexC = listaControle.IndexOf(controle);

                controle.positionC = listaControle.IndexOf(controle);
                controle.fly = null;
                controle.frog = null;
                controle.sugar = sugar;
                controle.thread = null;

                Controls.Add(sugar.picture);
                sugarCont++;
            }
            tempo++;
            TimeSpan valor = TimeSpan.FromSeconds(tempo);
            labelTimer.Text = "Tempo: " + valor.Hours.ToString("D2") + ":" + valor.Minutes.ToString("D2") + ":" + valor.Seconds.ToString("D2");
        }

        public void att()
        {
            frogCont = 0;
            flyCont = 0;
            sugarCont = 0;
            foreach(Controle aux in listaControle)
            {
                if (aux.frog != null) frogCont++;
                if (aux.fly != null) flyCont++;
                if (aux.sugar != null) sugarCont++;
            }
        }
        public void newFly()
        {
            fly = new Fly();
            t = new Thread(fly.move);

            int x = fly.picture.Location.X + 25;
            int y = fly.picture.Location.Y + 25;

            controle = new Controle(x, y, FLY, listaControle);

            listaControle.Add(controle);

            fly.indexC = listaControle.IndexOf(controle);

            controle.positionC = listaControle.IndexOf(controle);
            controle.fly = fly;
            controle.frog = null;
            controle.sugar = null;
            controle.thread = t;

            fly.s_mutex = s_mutex;

            fly.listaControle = listaControle;

            Controls.Add(fly.picture);
            flyCont++;
            fly.flagFly = false;
            controle.thread.Start();
        }       
    }
}
