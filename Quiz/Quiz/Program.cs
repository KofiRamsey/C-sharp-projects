using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Quiz Game!");

        // Define the quiz questions
        List<Question> questions = new List<Question>
        {
            new Question("What does HTML stand for?",
                new List<string>
                {
                    "Hypertext Markup Language", "Hyperlinks and Text Markup Language", "Home Tool Markup Language",
                    "Hyperlink and Textual Markup Language"
                }, 0),
            new Question("What is the function of a router in a computer network?",
                new List<string>
                {
                    "Translate domain names to IP addresses", "Connect multiple networks together",
                    "Store and retrieve website files", "Manage email communication"
                }, 1),
            new Question("Which programming language is commonly used for web development?",
                new List<string> { "Python", "Java", "C#", "JavaScript" }, 3),
            new Question("What does CPU stand for?",
                new List<string>
                {
                    "Central Processing Unit", "Computer Personal Unit", "Central Personal Unit",
                    "Computer Processing Unit"
                }, 0),
            new Question("What is the purpose of an operating system?",
                new List<string>
                {
                    "Run software applications", "Store and manage data", "Connect to the internet",
                    "Manage computer hardware and software resources"
                }, 3),
            new Question("What is the difference between RAM and ROM?",
                new List<string>
                {
                    "RAM is volatile, while ROM is non-volatile",
                    "RAM stores data, while ROM stores program instructions",
                    "RAM is read-only, while ROM is read-write", "RAM is faster than ROM"
                }, 0),
            new Question("What is the purpose of a firewall?",
                new List<string>
                {
                    "Protect against computer viruses", "Prevent unauthorized access to a network",
                    "Store and manage network data", "Optimize network performance"
                }, 1),
            new Question("What is the function of a DNS server?",
                new List<string>
                {
                    "Translate domain names to IP addresses", "Store website files", "Manage email communication",
                    "Encrypt data transmission"
                }, 0),
            new Question("What is the difference between HTTP and HTTPS?",
                new List<string>
                {
                    "HTTP is faster than HTTPS", "HTTP is secure, while HTTPS is not",
                    "HTTP uses port 80, while HTTPS uses port 443",
                    "HTTP is used for static websites, while HTTPS is used for dynamic websites"
                }, 2),
            new Question("What is the purpose of a cache in a computer system?",
                new List<string>
                {
                    "Store temporary internet files", "Improve system performance by storing frequently accessed data",
                    "Encrypt sensitive data", "Manage user authentication"
                }, 1),
            new Question("What is the function of an IP address?",
                new List<string>
                {
                    "Identify a specific website", "Identify a specific computer or device on a network",
                    "Store and manage website data", "Encrypt network traffic"
                }, 1),
            new Question("What is the file extension for a Python source code file?",
                new List<string> { ".py", ".exe", ".doc", ".txt" }, 0),
            new Question("What is the purpose of a compiler?",
                new List<string>
                {
                    "Run software applications", "Translate high-level programming code into machine code",
                    "Manage computer hardware resources", "Encrypt data transmission"
                }, 1),
            new Question("What is the difference between a LAN and a WAN?",
                new List<string>
                {
                    "LAN is wireless, while WAN is wired", "LAN covers a smaller geographic area than WAN",
                    "LAN is faster than WAN", "LAN is used for home networks, while WAN is used for business networks"
                }, 1),
            new Question("What is the purpose of an SSL certificate?",
                new List<string>
                {
                    "Securely store passwords", "Encrypt data transmission", "Block malicious websites",
                    "Authenticate user identities"
                }, 1),
            new Question("What is the difference between a virus and malware?",
                new List<string>
                {
                    "There is no difference, they are the same", "Viruses are more dangerous than malware",
                    "Malware is a broader term that includes viruses", "Viruses are physical, while malware is digital"
                }, 2),
            new Question("What is the function of a proxy server?",
                new List<string>
                {
                    "Filter internet content", "Store and retrieve website files", "Manage email communication",
                    "Translate domain names to IP addresses"
                }, 0),
            new Question("What is the purpose of an API (Application Programming Interface)?",
                new List<string>
                {
                    "Create user interfaces for applications", "Manage computer hardware resources",
                    "Store and manage data in a database",
                    "Allow different software applications to communicate and share data"
                }, 3),
            new Question("What is the difference between a hard disk drive (HDD) and a solid-state drive (SSD)?",
                new List<string>
                {
                    "HDDs are faster than SSDs", "HDDs have higher storage capacity than SSDs",
                    "SSDs are more durable and faster than HDDs",
                    "SSDs are used for external storage, while HDDs are used for internal storage"
                }, 2),
            new Question("What is the purpose of a version control system (VCS) such as Git?",
                new List<string>
                {
                    "Manage software development projects", "Optimize computer network performance",
                    "Protect against computer viruses", "Track and manage changes to source code"
                }, 3),
            new Question("What is the difference between HTTP and FTP?",
                new List<string>
                {
                    "HTTP is used for file transfer, while FTP is used for website communication",
                    "HTTP is more secure than FTP", "HTTP uses port 21, while FTP uses port 80",
                    "HTTP is faster than FTP"
                }, 0),
            new Question("What is the purpose of a virtual machine?",
                new List<string>
                {
                    "Run multiple operating systems on a single physical machine", "Encrypt network traffic",
                    "Store and manage website files", "Translate domain names to IP addresses"
                }, 0),
            new Question("What is the difference between a software developer and a software engineer?",
                new List<string>
                {
                    "There is no difference, they are the same",
                    "Software developers focus on coding, while software engineers focus on the entire development process",
                    "Software engineers have a higher salary than software developers",
                    "Software developers work on hardware, while software engineers work on software"
                }, 1),
            new Question("What is the purpose of a SQL database?",
                new List<string>
                {
                    "Store and manage data in a structured manner", "Protect against computer viruses",
                    "Encrypt data transmission", "Run software applications"
                }, 0)
        };

        int totalQuestions = questions.Count;
        int currentQuestion = 0;
        int score = 0;

        while (currentQuestion < totalQuestions)
        {
            Console.WriteLine("\nQuestion {0} of {1}:", currentQuestion + 1, totalQuestions);
            Question question = questions[currentQuestion];
            Console.WriteLine(question.Text);

            for (int i = 0; i < question.Choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {question.Choices[i]}");
            }

            Console.Write("Enter your answer (1-{0}): ", question.Choices.Count);
            string answer = Console.ReadLine();

            if (int.TryParse(answer, out int userChoice) && userChoice >= 1 && userChoice <= question.Choices.Count)
            {
                int correctChoice = question.CorrectChoiceIndex;
                if (userChoice - 1 == correctChoice)
                {
                    Console.WriteLine("Correct answer!");
                    score++;
                }
                else
                {
                    Console.WriteLine("Wrong answer. The correct answer is: {0}", question.Choices[correctChoice]);
                }

                currentQuestion++;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and {0}.", question.Choices.Count);
            }
        }

        Console.WriteLine("\nQuiz finished!");
        Console.WriteLine("Your score: {0}/{1}", score, totalQuestions);
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}

class Question
{
    public string Text { get; set; }
    public List<string> Choices { get; set; }
    public int CorrectChoiceIndex { get; set; }

    public Question(string text, List<string> choices, int correctChoiceIndex)
    {
        Text = text;
        Choices = choices;
        CorrectChoiceIndex = correctChoiceIndex;
    }
}
