using Clavister.ToDo.DataWriter;
using Clavister.ToDo.Models.Models;
using Clavister.ToDo.Storage.Implementation;

namespace TEST;

    internal class Program
    {
        static void Main(string[] args)
        {

            string filePath = Environment.CurrentDirectory + "/tasks.bin";

            var items = new List<TaskModel>()
            {
                new() { Id = 1, Title = "Task 1", Description = "Description 1", IsCompleted = false },
                new() { Id = 2, Title = "Task 2", Description = "Description 2", IsCompleted = true },
                new() { Id = 3, Title = "Task 3", Description = "Description 3", IsCompleted = false }
            };

            var serializer = new DataSerializer();  
            LocalStore store = new(serializer);
            //store.Save(items, filePath).Wait();

            var loadData = store.Load<TaskModel>(filePath);
            loadData.Wait();
            loadData.Result.ToList().ForEach(x => Console.WriteLine(x.Description));

            Console.Read();

        }
    }


