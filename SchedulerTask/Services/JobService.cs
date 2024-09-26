using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace SchedulerTask.Services
{
    public class JobService : BackgroundService
    {
        private Timer _timer;
        private readonly IConfiguration? _configuration;
        private readonly string? _connectionString;

        public JobService(IConfiguration? configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var now = DateTime.Now;
            //var nextRunTime = new DateTime(now.Year, now.Month, now.Day, 12, 10, 0, 0);
            var nextRunTime = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0, 0);

            if (now > nextRunTime)
            {
                nextRunTime = nextRunTime.AddDays(1);
            }
            var initialDelay = nextRunTime - now;

            _timer = new Timer(DoWork, null, initialDelay, TimeSpan.FromDays(1));

            //_timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(2));

            return Task.CompletedTask;
        }

        private async void DoWork(object state)
        {
            await RunDailyJobSchedulerTask();
        }

        public override Task StopAsync(CancellationToken stoppingToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            _timer?.Dispose();
            base.Dispose();
        }

        public async Task RunDailyJobSchedulerTask()
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();

                var result = await connection.ExecuteAsync("SchedulerTask", commandType: CommandType.StoredProcedure, commandTimeout: 0);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}
