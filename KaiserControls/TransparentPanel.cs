﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kaiser {
    public partial class TransparentPanel : Panel {
        private const int WS_EX_TRANSPARENT = 0x20;

        public TransparentPanel(IContainer container) {
            SetStyle(ControlStyles.Opaque, true);
            container.Add(this);
        }

        public int opacity = 100;

        [DefaultValue(0)]
        public int Opacity {
            get {
                return this.opacity;
            } set {
                this.opacity = value;
            }

        }

        protected override CreateParams CreateParams {
            get {
                CreateParams cpar = base.CreateParams;
                cpar.ExStyle = cpar.ExStyle | WS_EX_TRANSPARENT;
                return cpar;
            }
        }

        protected override void OnPaint(PaintEventArgs e) {
            using (var brush = new SolidBrush(Color.FromArgb
               (this.opacity * 255 / 100, this.BackColor))) {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
            
            base.OnPaint(e);
        }

    }
}
