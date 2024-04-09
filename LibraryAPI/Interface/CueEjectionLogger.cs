namespace LibraryAPI.Interface
{
    public class CueLoggingService : IHostedService, IDisposable
    {
        private readonly ICueEjectionTracker _cueEjectionTracker;
        private Timer _timer;

        public CueLoggingService(ICueEjectionTracker cueEjectionTracker)
        {
            _cueEjectionTracker = cueEjectionTracker;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            Console.WriteLine($"Total Cue Ejects: {_cueEjectionTracker.GetTotalCueEjects()}");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }

}