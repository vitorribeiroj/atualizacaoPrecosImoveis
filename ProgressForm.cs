﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ImoveisPrecoDesktopApp
{
    public partial class ProgressForm : Form
    {
        public ProgressForm()
        {
            InitializeComponent();
            progressBarConsulta.Style = ProgressBarStyle.Marquee;
            progressBarConsulta.MarqueeAnimationSpeed = 30; // Velocidade da animação
        }
    }
}
