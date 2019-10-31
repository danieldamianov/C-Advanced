using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Problem_4___Hospital
{
    class Patient
    {
        public string Name { get; set; }
        public string Doctor { get; set; }
        public Patient(string n,string d)
        {
            this.Name = n;
            this.Doctor = d;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<List<Patient>>> departments = new Dictionary<string, List<List<Patient>>>();
            string input;
            while ((input = Console.ReadLine()) != "Output")
            {
                string department = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0];
                string doctor = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1] + input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[2];
                string patientName = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[3];
                Patient currentPatient = new Patient(patientName, doctor);
                if (departments.ContainsKey(department) == false)
                {
                    departments.Add(department, new List<List<Patient>>());
                }
                if (departments[department].Count == 20 && departments[department][19].Count == 3)
                {
                    continue;
                }
                int indexOfcurrentRoom = departments[department].Count - 1;
                if (indexOfcurrentRoom == -1)
                {
                    departments[department].Add(new List<Patient>());
                    indexOfcurrentRoom = 0;
                }
                if (departments[department][indexOfcurrentRoom].Count < 3)
                {
                    departments[department][indexOfcurrentRoom].Add(currentPatient);
                }
                else
                {
                    departments[department].Add(new List<Patient>());
                    departments[department][indexOfcurrentRoom + 1].Add(currentPatient);
                }
            }
            while ((input = Console.ReadLine()) != "End")
            {
                string[] commandArgs = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (commandArgs.Length == 1)
                {
                        foreach (var room in departments[commandArgs[0]])
                        {
                            foreach (var patient in room)
                            {
                                Console.WriteLine(patient.Name);
                            }
                        }
                }
                else if(commandArgs[1].All(char.IsDigit))
                {
                    foreach (var patient in departments[commandArgs[0]][int.Parse(commandArgs[1]) - 1].OrderBy(x => x.Name))
                    {
                        Console.WriteLine(patient.Name);
                    }
                }
                else
                {
                    List<string> list = new List<string>();
                    foreach (var dep in departments)
                    {
                        foreach (var room in departments[dep.Key])
                        {
                            foreach (var patient in room)
                            {
                                if (patient.Doctor == commandArgs[0] + commandArgs[1])
                                {
                                    list.Add(patient.Name);
                                }
                            }
                        }
                    }
                    Console.WriteLine(string.Join(Environment.NewLine,list.OrderBy(x => x)));
                    
                }
            }
            /*
            foreach (var dep in departments)
            {
                Console.WriteLine($"Dep {dep.Key}: ");
                foreach (var room in departments[dep.Key])
                {
                    Console.WriteLine($"room: {dep.Value.IndexOf(room)}");
                    foreach (var patient in room)
                    {
                        Console.WriteLine(patient.Name + " " + patient.Doctor);
                    }
                    Console.WriteLine("end of room");
                }
                Console.WriteLine("end of dep");
            }
            */
        }
    }
}
