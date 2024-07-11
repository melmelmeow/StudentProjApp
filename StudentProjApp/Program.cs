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
                    Console.WriteLine("Invalid character, please try again.");
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
                        Console.WriteLine("Exiting the registration.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
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
            Console.Write("Is this correct? (yes/no): ");
            string confirmation = Console.ReadLine();

            if (confirmation.ToLower() == "yes")
           {
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
           else
           { 
                Console.WriteLine("Student addition cancelled.");
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
                    Console.WriteLine("Invalid character, please try again.");
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
                    Console.WriteLine("Student Found:");
                    Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age:{ student.Age}, Course: { student.Course}");                
                    return;
                }
            }
            Console.WriteLine("Student not found.");
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
            
            Console.Write("Are you sure you want to update this student? (yes/no): ");
            string confirmation = Console.ReadLine().ToLower();
            
            if (confirmation == "yes")
            {
                students[i].Name = newName;
                students[i].Age = newAge;
                students[i].Course = newCourse;
                Console.WriteLine("Student updated successfully.");
            }
            else
            {
                Console.WriteLine("Update cancelled.");
            }
            return;
        }
    }
    Console.WriteLine("Student not found.");
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
                    int choice = GetValidIntInput("Enter your choice (1 for yes, 2 for no): ");
                    // TODO: much better with switch statement
                    if (choice == 1)
                    {
                        // remove the record by index
                        students[studentIdx] = null;                        
                        studentCount = studentCount - 1;
                        Console.WriteLine("Student deleted successfully." + studentId);
                    return;
                    }
                    else if (choice == 2)
                    {
                        Console.WriteLine("Deletion cancelled.");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please try again.");
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
                Console.WriteLine("No students to display.");
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
