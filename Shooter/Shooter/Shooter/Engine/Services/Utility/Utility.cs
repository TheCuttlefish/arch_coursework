using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Timers;

namespace GameEngine
{

   public class Utility : Microsoft.Xna.Framework.Game {
        public bool paused;
        public Color background;
        public Color currentColour;
        public Color newColour;
        MyGame main;

        List< Timer > timers = new List< Timer >();

        public Utility( MyGame _main ) {

            main = _main;
            background = Color.DarkCyan;
            paused = false;
            newColour = currentColour = Color.White ;
        }

        public void Update() {

            main.utility.currentColour = Color.Lerp( main.utility.currentColour, newColour, 0.01f );

            if ( main.GameInput.PAUSE ) {

                paused = !paused;
                if (paused) PauseTimers();
                if (!paused) StartTimers();
            }

            if ( paused ) background = Color.Gray * 0.3f;
            else background = currentColour;
        }

        public void PauseTimers() {
            foreach(var timer in timers)
            {
                timer.Stop();
            }
        }

        public void StartTimers() {
            foreach(var timer in timers) {
                timer.Start();
            }
        }

        public void DeleteTimers() {
            foreach(var timer in timers) {
                timer.Stop();
            }
            timers.Clear();
        }

        public void CallAfter(float timeInSeconds, Action myMethod) {
            var myTimer = new Timer(timeInSeconds * 1000.0f);
            myTimer.Elapsed += (sender, eventParams) => {
                myMethod();
                myTimer.Stop();
                timers.Remove(myTimer);
            };
            myTimer.Start();
            timers.Add(myTimer);
        }


        public void RepeatEvery(float timeInSeconds, Action myMethod) {

            var myTimer = new Timer(timeInSeconds * 1000.0f);
            myTimer.Elapsed += (sender, eventParams) => {
                myMethod();
            };
            myTimer.Start();
            timers.Add(myTimer);
        }


        private readonly Random random = new Random();
        private  readonly object syncLock = new object();

        public int RandomRange(int min, int max) {

            lock (syncLock) {
                return random.Next(min, max);
            }
        }

    }

}
