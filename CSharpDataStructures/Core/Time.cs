namespace XIV.Core
{
    using System.Diagnostics;

    public static class Time
    {
        /// <summary>
        /// Time passed between frames in seconds
        /// </summary>
        public static float DeltaTime => deltaTime;

        /// <summary>
        /// Time passed since the application start
        /// </summary>
        public static float TimeSinceStartup => timeSinceStartup;


        static float deltaTime;
        static float timeSinceStartup;
        static Stopwatch stopwatch = new Stopwatch();

        internal static void Start()
        {
            stopwatch.Start();
        }

        internal static void Update()
        {
            deltaTime = stopwatch.ElapsedMilliseconds / 1000f;
            timeSinceStartup += deltaTime;

            stopwatch.Restart();
        }

        internal static void Stop()
        {
            stopwatch.Stop();
        }

    }
}