using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace Shooter {
  class PlayerInputData {

    public Dictionary<string, Keys> keyMap = new Dictionary<string, Keys> () { 
      { "Left", Keys.Left },
      { "A", Keys.A },
      { "Right", Keys.Right },
      { "D", Keys.D },
      { "Up", Keys.Up },
      { "W", Keys.W },
      { "Down", Keys.Down },
      { "S", Keys.S },
      {"Space", Keys.Space },
      {"P", Keys.P },
      {"C", Keys.C },
      {"Back", Keys.Back }
    };

    public Dictionary<string, Buttons> buttonMap = new Dictionary<string, Buttons>() {

        {"Left" , Buttons.DPadLeft  },
        {"Right" , Buttons.DPadRight  },
        {"Up" , Buttons.DPadUp  },
        {"Down" , Buttons.DPadDown  },
        {"A" , Buttons.A  },
        {"RightTrigger" , Buttons.RightTrigger },
        {"Start" , Buttons.Start },
        {"Back" , Buttons.Back }

    };

        public KeyData left;
        public KeyData right;
        public KeyData up;
        public KeyData down;
        public KeyData fire;
        public KeyData pause;
        public KeyData clear;
        public KeyData quit;
    }

  class KeyData {
    public string[] keys;
    public string[] buttons;
  }

}