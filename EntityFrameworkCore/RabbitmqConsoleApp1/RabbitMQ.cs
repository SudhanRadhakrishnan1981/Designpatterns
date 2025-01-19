using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace LearningConsoleApp
{
    public class RabbitMQ
    {
        public async void run()
        {

            //Here we specify the Rabbit MQ Server. we use rabbitmq docker image and use it
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };
            //Create the RabbitMQ connection using connection factory details as i mentioned above
            //Create the RabbitMQ connection using connection factory details as i mentioned above
            var connection = await factory.CreateConnectionAsync();

            using var channel = await connection.CreateChannelAsync();
            //declare the queue after mentioning name and a few property related to that
            channel.QueueDeclareAsync("product", exclusive: false);
            //Set Event object which listen message from chanel which is sent by producer
            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += async (model, eventArgs) =>
            {
                try
                {
                    // Process the message
                    var body = eventArgs.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);

                    // Simulate processing (if needed)
                    await Task.Delay(100); // Simulate async processing
                    Console.WriteLine($"Product message received: {message}");

                    // Acknowledge the message
                    channel.BasicAckAsync(eventArgs.DeliveryTag, false);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing message: {ex.Message}");

                    // Optionally, negatively acknowledge the message
                    channel.BasicNackAsync(eventArgs.DeliveryTag, false, requeue: true);
                }
            };//read the message
            channel.BasicConsumeAsync(queue: "product", autoAck: true, consumer: consumer);


        }
    }
}
