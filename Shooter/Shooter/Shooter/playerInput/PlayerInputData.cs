using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace Shooter {
  class PlayerInputData {

    public Dictionary<string, Keys> keyMap = new Dictionary<string, Keys> () { 
      { "left", Keys.Left },
      { "a", Keys.A }
    };

    public KeyData left;

  }

  class KeyData {
    public string[] keys;
    public string pad;
  }

}