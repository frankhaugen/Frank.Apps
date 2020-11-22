using System.Collections.Generic;
using System.Numerics;

namespace Frank.Apps.Snake
{
    public class Snake
    {
        public Snake()
        {
            IsAlive = true;
            Body = new Queue<Vector2>();
        }

        public bool IsAlive { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 TargetPosition { get; set; }
        public Queue<Vector2> Body { get; }
        public Speed Speed { get; set; }

        public int Length { get; set; }
    }
}
