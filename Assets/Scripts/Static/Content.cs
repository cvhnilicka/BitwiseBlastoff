using System;
using System.Collections.Generic;

static class Content 
{
    public static string Question = "T [] T = T";
    public static string Answer = "AND";
    public static string PossibleAnswers = "OR,AND,XOR";

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


        // XOR
        new Question("T XOR T = []", "T XOR T = F", "F", "T","","F"),
        new Question("F XOR F = []", "F XOR F = F", "F", "T","","F"),
        new Question("F XOR T = []", "F XOR T = T", "T", "T","","F"),
        new Question("T XOR F = []", "T XOR F = F", "T", "T","","F"),

        // NAND
        new Question("F NAND F = []","F NAND F = T", "T", "T", "", "F"),
        new Question("T NAND F = []","T NAND F = T", "T", "T", "", "F"),
        new Question("F NAND T = []","F NAND T = T", "T", "T", "", "F"),
        new Question("T NAND T = []","T NAND T = F", "F", "T", "", "F"),

        // NOR
        new Question("F NOR F = []", "F NOR F = T", "T", "T","","F"),
        new Question("F NOR T = []", "F NOR T = F", "F", "T","","F"),
        new Question("T NOR F = []", "T NOR F = F", "F", "T","","F"),
        new Question("T NOR T = []", "T NOR T = F", "F", "T","","F"),

        // XNOR
        new Question("F XNOR F = []", "F XNOR F = T", "T", "T", "","F"),
        new Question("T XNOR T = []", "T XNOR T = T", "T", "T", "","F"),
        new Question("F XNOR T = []", "F XNOR T = F", "F", "T", "","F"),
        new Question("T XNOR F = []", "T XNOR F = F", "F", "T", "","F"),
    };


    private static int currentIndex = 0;

    public static void AdvanceIndex() {
        currentIndex += 1;
        if (currentIndex > questions.Count)
        {
            currentIndex = 0;
            ShuffleDeck();
        }
    }
    public static int GetCurrentIndex() { return currentIndex; }


    public static void ShuffleDeck()
    {
        for(int i = 0; i < questions.Count; i++)
        {
            Question temp = questions[i];
            Random rn = new Random();
            int randomIndex = rn.Next(i, questions.Count);
            questions[i] = questions[randomIndex];
            questions[randomIndex] = temp;
        }
    }

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
