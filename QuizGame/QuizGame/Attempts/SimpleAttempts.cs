namespace QuizGame.Attempts
{
    public class SimpleAttempts : IAttempts
    {
        private readonly int max;
        private int current;

        public SimpleAttempts(int max, int current = 0)
        {
            this.max = max;
            this.current = current;
        }

        public bool Over => current >= max;

        public void Use()
        {
            current++;
        }
    }
}