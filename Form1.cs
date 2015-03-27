using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeostraTimer
{
    public partial class Form1 : Form
    {
        const int basetime = 100;
        int time = 100; 
        Timer atimer = new Timer();
        SoundPlayer simpleSound = new SoundPlayer(Properties.Resources.beep);

        public Form1()        {
            InitializeComponent();
            textBox1.Text = time.ToString();
            atimer.Tick += new EventHandler(OnTimedEvent);
            atimer.Interval = 1000;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            this.Icon = Properties.Resources.Icon1;
        }

        private void Start()
        {
            atimer.Start();
            button1.Text = "Stop";
        }

        private void Reset()
        {
            atimer.Stop();
            button1.Text = "Start";
            time = basetime;
            textBox1.Text = time.ToString();
        }
        private void OnTimedEvent(object sender, EventArgs e)
        {
            if (time > 0)
            {
                time = time - 1;
                if (time < 11)
                    simpleSound.Play();
                textBox1.Text = time.ToString();
            }
            else
            {
                atimer.Stop();
                Reset();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.NumPad1)
            {
                Start();
            }
            else if (e.KeyCode == Keys.NumPad2)
            {
                Reset();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Start")
            {
                Start();
            }
            else
            {
                Reset();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pour démarrer le Timer utiliser la touche Pavé Numérique 1 et pour le reset la touche Pavé Numérique 2", "Aide", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
