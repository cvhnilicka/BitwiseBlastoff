using System.Collections.Generic;

static class Content 
{
    public static string Question = "T [] T = T";
    public static string Answer = "AND";
    public static string PossibleAnswers = "OR,AND,XOR";

    public static Dictionary<string, Question> expressions = new Dictionary<string, Question>()
    {
        { "T[]T=T", new Question("T[]T=T","T AND T = T", "AND", "NAND", "XOR", "AND") },
        { "T[]F=T", new Question("T[]T=T","T OR T = T", "OR", "OR", "NAND", "AND") },

    };

    public static List<Question> questions = new List<Question>()
    {
        new Question("T[]T=T","T AND T = T", "AND", "NAND", "XOR", "AND"),
        new Question("T[]F=T","T OR F = T", "OR", "OR", "NAND", "AND")
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
