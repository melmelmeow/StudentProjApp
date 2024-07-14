using System;
using System.Formats.Asn1;
using System.Xml.Serialization;
namespace proj
{
    public static class Program
    {
        private static Student[] students = new Student[56];
        private static int studentCount = 0;
        public static void Main(string[] args)
        {
            while (true)
            {
                DisplayMenu();
                string choice = Console.ReadLine();
                if (!IsNumeric(choice))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid character, please try again.");
                    Console.ResetColor();
                    continue;
                }
                switch (choice)
                {
                    case "1":
                        AddStudent();
                        break;
                    case "2":
                        SearchStudent();
                        break;
                    case "3":
                        UpdateStudent();
                        break;
                    case "4":
                        DeleteStudent();
                        break;
                    case "5":
                        ListAllStudents();
                        break;
                    case "6":
                        Console.WriteLine("Exiting the registration? ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("(1 for yes) "); 
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("(2 for no): ");
                        Console.ResetColor();
                        string input = Console.ReadLine();
                        if (input.ToLower() == "1") 
                        {
                        // Add code for "yes" case
                        } 
                        else if (input.ToLower() == "2") 
                        {
                        // Add code for "no" case
                        }
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice, please try again.");
                        Console.ResetColor();
                        break;
                }
            }
        }
        public static void DisplayMenu()
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine(" Student Registration Form ");
            Console.WriteLine("1. Add New Student");
            Console.WriteLine("2. Search for Student");
            Console.WriteLine("3. Update Student");
            Console.WriteLine("4. Delete Students");
            Console.WriteLine("5. List All Students");
            Console.WriteLine("6. Exit");
            Console.WriteLine("-----------------------------");
            Console.Write("Enter your choice: ");
        }
        public static void AddStudent()
        {
            Console.WriteLine("Add New Student");
            Console.WriteLine("----------------");
            int studentId = GetValidIntInput("Enter Student ID: ");
            Console.Write("Enter Student Name: ");
            string studentName = Console.ReadLine();
            int studentAge = GetValidIntInput("Enter Student Age: ");
            Console.Write("Enter Student Course: ");
            string studentCourse = Console.ReadLine();
            Console.WriteLine("Confirm student details:");
            Console.WriteLine($"ID: {studentId}, Name: {studentName}, Age: {studentAge}, Course: {studentCourse}");
            Console.WriteLine("Is this correct? ");
            Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("(1 for yes) "); 
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("(2 for no): ");
                        Console.ResetColor();
            string confirmation = Console.ReadLine();

            if (confirmation.ToLower() == "1")
           {
                students[studentCount] = new Student
                {
                   Id = studentId,
                   Name = studentName,
                   Age = studentAge,
                   Course = studentCourse
                };
               studentCount++;
               Console.ForegroundColor = ConsoleColor.Green;
               Console.WriteLine("Student added successfully.");
               Console.ResetColor();
           }
           else
           { 
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Student addition cancelled.");
                Console.ResetColor();
           }
        }
            /*
            students[studentCount] = new Student
            {
                Id = studentId,
                Name = studentName,
                Age = studentAge,
                Course = studentCourse
            };
            studentCount++;
            Console.WriteLine("Student added successfully.");
        }
        /**
         * Get valid integer input
         */
        public static int GetValidIntInput(string prompt)
        {
            int result;
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();

                if (!int.TryParse(input, out result))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid character, please try again.");
                    Console.ResetColor();
                }
            } while (!int.TryParse(input, out result));
            return result;
        }
        public static bool IsNumeric(string input)
        {
            return int.TryParse(input, out _);
        }
        public static void SearchStudent()
        {
            Console.WriteLine("Search Student");
            Console.WriteLine("----------------");
            int studentId = GetValidIntInput("Enter Student ID you want to access: ");
            foreach (var student in students)
            {
                if (student != null && student.Id == studentId)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Student Found:");
                    Console.ResetColor();
                    Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age:{ student.Age}, Course: { student.Course}");                
                    return;
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Student not found.");
            Console.ResetColor();
        }
        public static void UpdateStudent()
        {
            Console.WriteLine("Update Student");
            Console.WriteLine("----------------");
            int studentId = GetValidIntInput("Enter Student ID you want to update: ");
    for (int i = 0; i < studentCount; i++)
    {
        if (students[i].Id == studentId)
        {
            Console.WriteLine("Student Found:");
            Console.Write("Enter new Student Name: ");
            string newName = Console.ReadLine();
            int newAge = GetValidIntInput("Enter new Student Age: ");
            Console.Write("Enter new Student Course: ");
            string newCourse = Console.ReadLine();
            
            Console.WriteLine("You are about to update the student with the following details:");
            Console.WriteLine("ID: " + studentId);
            Console.WriteLine("Name: " + newName);
            Console.WriteLine("Age: " + newAge);
            Console.WriteLine("Course: " + newCourse);
            Console.WriteLine("Are you sure you want to update this student? ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("(1 for yes) "); 
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("(2 for no): ");
                        Console.ResetColor();
            string confirmation = Console.ReadLine().ToLower();
            if (confirmation == "1")
            {
                students[i].Name = newName;
                students[i].Age = newAge;
                students[i].Course = newCourse;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Student updated successfully.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Update cancelled.");
                Console.ResetColor();
            }
            return;
        }
    }
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Student not found.");
    Console.ResetColor();
            // TODO much better of traversing foreach
            /*
               for (int i = 0; i < studentCount; i++)
            {
                if (students[i].Id == studentId)
                {
                    Console.Write("Enter new Student Name: ");
                    students[i].Name = Console.ReadLine();
                    students[i].Age = GetValidIntInput("Enter new Student Age: ");
                    Console.Write("Enter new Student Course: ");
                    students[i].Course = Console.ReadLine();
                    Console.WriteLine("Student updated successfully.");
                    return;

                }
            }
            Console.WriteLine("Student not found."); */
        }
        public static void DeleteStudent()
        {
            Console.WriteLine("Delete Student");
            Console.WriteLine("----------------");
            int studentId = GetValidIntInput("Enter Student ID you want to delete: ");
            // add counter for index students
            int studentIdx = 0;
            foreach (var student in students)
            {
                if (student != null && student.Id == studentId)
                {
                    // get the counter
                    Console.WriteLine("Student Found:");
                    Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age:{ student.Age}, Course: { student.Course}");
                    // put a confirmation statement
                    Console.WriteLine("Do you really want to delete this Student ID? ");
                    // get the confirmation
                    int choice = GetValidIntInput("Enter your choice ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("(1 for yes) "); 
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("(2 for no): ");
                        Console.ResetColor();
                    // TODO: much better with switch statement
                    if (choice == 1)
                    {
                        // remove the record by index
                        students[studentIdx] = null;                        
                        studentCount = studentCount - 1;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Student deleted successfully." + studentId);
                        Console.ResetColor();
                    return;
                    }
                    else if (choice == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Deletion cancelled.");
                        Console.ResetColor();
                        return;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice. Please try again.");
                        Console.ResetColor();
                    }
                }
                studentIdx++;
            }
        }
        public static void ListAllStudents()
        {
            Console.WriteLine("List All Students:");
            Console.WriteLine("----------------");
            if (studentCount == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No students to display.");
                Console.ResetColor();
            }
            else
            {
                foreach (var student in students) 
                {
                    // exclude empty indexes
                    if (student != null)
                    {
                        Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age:{student.Age}, Course: {student.Course}");
                    }
                }
            }
        }
        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public string Course { get; set; }
        }

    }
}
