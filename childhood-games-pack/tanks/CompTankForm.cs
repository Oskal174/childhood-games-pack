﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;


namespace childhood_games_pack.tanks {
    public partial class CompTankForm : Form {
        private enum DIRECTIONS : int {
            UP      = 1,
            DOWN    = 2,
            LEFT    = 3,
            RIGHT   = 4
        }

        private TANK_TYPE type;
        private SPEED_LEVEL speedLevel;

        private int step; // pxl
        private int stepTimer; // ms

        public CompTankForm(TANK_TYPE type, SPEED_LEVEL speedLevel, Point spot) {
            InitializeComponent();
            SetTopLevel(false);
            AutoSize = false;

            this.type = type;
            this.speedLevel = speedLevel;

            speedInit();
            shape();
            Location = spot;
            walkAndAttackWorker.RunWorkerAsync();
        }

        private void speedInit() {
            switch (speedLevel) {
                case SPEED_LEVEL.LOW:
                    step = 20;
                    stepTimer = 3000;
                    break;

                case SPEED_LEVEL.MEDIUM:
                    step = 20;
                    stepTimer = 2000;
                    break;

                case SPEED_LEVEL.HIGHT:
                    step = 20;
                    stepTimer = 1000;
                    break;

                case SPEED_LEVEL.NONE:
                default:
                    throw new Exception("Wrong speed level");
            }
        }

        //! Change shape of form depending on the tank-type.
        private void shape() {
            switch (type) {
                case TANK_TYPE.LIGHT:
                    BackgroundImage = Properties.Resources.light_tank;
                    break;

                case TANK_TYPE.MEDIUM:
                    BackgroundImage = Properties.Resources.medium_tank;
                    break;

                case TANK_TYPE.HEAVY:
                    BackgroundImage = Properties.Resources.heavy_tank;
                    break;

                case TANK_TYPE.NONE:
                default:
                    throw new Exception("Wrong type of Tank");
            }
        }

        private void walkAndAttackWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {
            Random rnd = new Random();

            while (true) {
                DIRECTIONS direction = (DIRECTIONS)(rnd.Next() % 4);
                switch (direction) {
                    case DIRECTIONS.UP:
                        Location = new Point(Location.X, Location.Y - step);
                        break;

                    case DIRECTIONS.DOWN:
                        Location = new Point(Location.X, Location.Y + step);
                        break;

                    case DIRECTIONS.LEFT:
                        Location = new Point(Location.X - step, Location.Y);
                        break;

                    case DIRECTIONS.RIGHT:
                        Location = new Point(Location.X + step, Location.Y);
                        break;
                }

                Thread.Sleep(stepTimer);
            }
        }
    }
}
