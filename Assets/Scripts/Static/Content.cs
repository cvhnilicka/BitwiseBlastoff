using System.Collections.Generic;

static class Content 
{
    public static string Question = "T [] T = T";
    public static string Answer = "AND";
    public static string PossibleAnswers = "OR,AND,XOR";

    public static Dictionary<string, Question> expressions = new Dictionary<string, Question>()
    {
        // AND SECTION
        { "T[]T=T", new Question("T[]T=T","T AND T = T", "AND", "NAND", "XOR", "AND") },
        // truth table section
        { "T AND F = []", new Question("T AND F = []","T AND F = F", "F", "T", "", "F") },
        { "F AND T = []", new Question("F AND T = []","F AND T = F", "F", "T", "", "F") },
        { "T AND T = []", new Question("T AND T = []","T AND T = T", "T", "T", "", "F") },
        { "F AND F = []", new Question("F AND F = []","F AND F = F", "F", "T", "", "F") },









        { "T[]F=T", new Question("T[]T=T","T OR T = T", "OR", "OR", "NAND", "AND") },

    };

    public static List<Question> questions = new List<Question>()
    {
        // AND Section
        new Question("T[]T=T","T AND T = T", "AND", "NAND", "XOR", "AND"),
        // truth table
        new Question("T AND F = []","T AND F = F", "F", "T", "", "F"),
        new Question("F AND T = []","F AND T = F", "F", "T", "", "F"),
        new Question("T AND T = []","T AND T = T", "T", "T", "", "F"),
        new Question("F AND F = []","F AND F = F", "F", "T", "", "F"),

        // OR Section
        new Question("T[]F=T","T OR F = T", "OR", "OR", "NAND", "AND"),
        // truth table
        new Question("T OR F = []","T OR F = T", "T", "T", "", "F"),
        new Question("F OR T = []","F OR T = T", "T", "T", "", "F"),
        new Question("T OR T = []","T OR T = T", "T", "T", "", "F"),
        new Question("F OR F = []","F OR F = F", "F", "T", "", "F"),


    };


    private static int currentIndex = 0;

    public static void AdvanceIndex() { currentIndex += 1; }
    public static int GetCurrentIndex() { return currentIndex; }


}

class Question
{
    public string expression;
    public string correctExpression;
    public string answer;
    public string[] options;

    public Question(string expression, string correctExpression, string answer,
        string optiona, string optionb, string optionc)
    {
        this.expression = expression;
        this.correctExpression = correctExpression;
        this.answer = answer;
        SetOptions(optiona, optionb, optionc);
    }

    public void SetOptions(string a, string b, string c)
    {
        if (a == null || b == null || c == null) return;
        options = new string[3];
        options[0] = a;
        options[1] = b;
        options[2] = c;
    }
}
