using System;

namespace GameEngine
{
#if WINDOWS || XBOX
    static class Program
    {
        static void Main( string[] args )
        {
            using ( MyGame game = new MyGame() )
            {
                game.Run();
            }
        }
    }
#endif
}

