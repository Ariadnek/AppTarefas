using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppTarefas
{
    public class Program
    {
        static string[] Scopes = { CalendarService.Scope.CalendarReadonly };
        static string ApplicationName = "AppTarefas";

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static void IntegrateWithGoogleCalendar()
        {
            try
            {
                UserCredential credential;

                using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
                {
                    string credPath = "token.json";
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.FromStream(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                }

                // Cria o serviço de calendário
                var service = new CalendarService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });

                // Define o tempo mínimo para o qual queremos listar eventos
                var request = service.Events.List("primary");
                request.TimeMinDateTimeOffset = DateTimeOffset.Now; // Usando TimeMinDateTimeOffset
                request.ShowDeleted = false;
                request.SingleEvents = true;
                request.MaxResults = 10;
                request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

                // Executa a requisição de eventos
                Events events = request.Execute();

                if (events.Items != null && events.Items.Count > 0)
                {
                    foreach (var eventItem in events.Items)
                    {
                        string start = eventItem.Start.DateTime.HasValue ?
                            eventItem.Start.DateTime.Value.ToString("g") : "Sem data";
                        MessageBox.Show($"Evento: {eventItem.Summary}\nInício: {start}", "Evento no Google Calendar");
                    }
                }
                else
                {
                    MessageBox.Show("Nenhum evento futuro encontrado.", "Google Calendar");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao integrar com o Google Calendar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}