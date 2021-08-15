using System;
using System.Diagnostics;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

// 학생 정보 입력(이름, 학년, 반, 주소, 취미)
// 학생 성적 입력(국, 영, 수)
// 학생 정보 엑셀에 저장
// 학생 정보 엑셀에 저장시 학생 번호 순서별로 자동 생성하여 엑셀에 저장
// 학생 정보 엑셀에서 가져오기
// 학생 시험 석차순 정렬하여 출력
// 학생 정보 전체 출력
// 학생 정보 번호순으로 검색하여 출력

// 데이터베이스가 없는 경우

namespace StudentsManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Student[] students = new Student[20];
            for(int i=0; i<20; i++)
            {
                students[i] = new Student(); // 각각의 배열에 stduent 클래스 객체들을 초기화
            }

            int result = 99;
            while(result != 0)
            {
                try
                {
                    Console.WriteLine("학생기록부 프로그램입니다.");
                    Console.WriteLine("어떤 작업을 하시겠습니까?" + Environment.NewLine);
                    Console.WriteLine("1. 학생 정보 입력 / 2. 학생 정보 출력 / 3. 학생 정보 검색 / 4. 점수 석차 출력 / 0. 프로그램 종료");
                    Console.WriteLine();
                    result = int.Parse(Console.ReadLine());

                    int studentCount = 0;
                    int ModeFlag = 0;

                    switch (result)
                    {
                        case 1:

                            // 학생 정보 입력
                            Console.WriteLine("학생 수를 입력하세요.");
                            studentCount = int.Parse(Console.ReadLine());
                            for (int i = 0; i < studentCount; i++)
                            {
                                try
                                {
                                    Console.WriteLine($"{i + 1}번 학생 정보를 입력받습니다.");
                                    Console.WriteLine(Environment.NewLine + "-----------------------------" + Environment.NewLine);
                                    Console.WriteLine($"{i + 1}번 학생의 이름을 입력하세요.");
                                    students[i].name = Console.ReadLine();
                                    Console.WriteLine(Environment.NewLine + "-----------------------------" + Environment.NewLine);
                                    Console.WriteLine($"{i + 1}번 학생의 학년을 입력하세요.");
                                    students[i].grade = Console.ReadLine();
                                    Console.WriteLine(Environment.NewLine + "-----------------------------" + Environment.NewLine);
                                    Console.WriteLine($"{i + 1}번 학생의 반을 입력하세요.");
                                    students[i].grade1 = Console.ReadLine();
                                    Console.WriteLine(Environment.NewLine + "-----------------------------" + Environment.NewLine);
                                    Console.WriteLine($"{i + 1}번 학생의 주소를 입력하세요.");
                                    students[i].address = Console.ReadLine();
                                    Console.WriteLine(Environment.NewLine + "-----------------------------" + Environment.NewLine);
                                    Console.WriteLine($"{i + 1}번 학생의 취미를 입력하세요.");
                                    students[i].hobby = Console.ReadLine();
                                }
                                catch
                                {
                                    Console.WriteLine("정확한 정보가 확인되지 않았습니다.");
                                    Console.ReadLine();
                                }
                            }

                            // 학생 점수 입력
                            for (int i = 0; i < studentCount; i++)
                            {
                                try
                                {
                                    Console.WriteLine($"{i + 1}번 학생 점수을 입력하세요.");
                                    Console.WriteLine(Environment.NewLine + "-----------------------------" + Environment.NewLine);
                                    Console.WriteLine($"{i + 1}번 학생의 국어 점수을 입력하세요.");
                                    students[i].KoreanScore = int.Parse(Console.ReadLine());
                                    Console.WriteLine(Environment.NewLine + "-----------------------------" + Environment.NewLine);
                                    Console.WriteLine($"{i + 1}번 학생의 영어 점수을 입력하세요.");
                                    students[i].EngScore = int.Parse(Console.ReadLine());
                                    Console.WriteLine(Environment.NewLine + "-----------------------------" + Environment.NewLine);
                                    Console.WriteLine($"{i + 1}번 학생의 수학 점수을 입력하세요.");
                                    students[i].MathScore = int.Parse(Console.ReadLine());

                                    students[i].average = students[i].average1(students[i].KoreanScore, students[i].EngScore, students[i].MathScore);
                                }
                                catch
                                {
                                    Console.WriteLine("점수가 잘못 입력되었습니다.");
                                    Console.ReadLine();
                                }
                            }

                            // 엑셀 입력
                            Manage.StudentWrite(students, studentCount);
                            break;

                        case 2:
                            // 학생 정보 출력
                            ModeFlag = 2;
                            students = Manage.StudentRead(students, ModeFlag);

                            break;

                        case 3:
                            // 학생 정보 검색
                            students = Manage.StudentRead(students, ModeFlag);
                            if (students[0].name != null)
                            {
                                while (true)
                                {
                                    Console.WriteLine("학생 번호로 학생의 정보를 검색합니다. ");
                                    Console.WriteLine("학생 번호를 입력하세요 / 0번을 누르면 종료.");
                                    try
                                    {
                                        int i = int.Parse(Console.ReadLine());

                                        if (i == 0)
                                        {
                                            Console.WriteLine("프로그램 종료");
                                            Console.ReadLine();
                                            break;
                                        }
                                        else if (students[i - 1].average != 0)
                                        {
                                            for (int j = 0; j < students.Length; j++)
                                            {
                                                if (students[j].number == i)
                                                {
                                                    Console.WriteLine($"{i}번 학생 신상 정보");
                                                    Console.WriteLine();
                                                    Console.WriteLine("이름 : " + students[i].name);
                                                    Console.WriteLine("학년 : " + students[i].grade);
                                                    Console.WriteLine("반 : " + students[i].grade1);
                                                    Console.WriteLine("주소 : " + students[i].address);
                                                    Console.WriteLine("취미 : " + students[i].hobby);
                                                    Console.WriteLine("국어점수 : " + students[i].KoreanScore);
                                                    Console.WriteLine("영어점수 : " + students[i].EngScore);
                                                    Console.WriteLine("수학점수 : " + students[i].MathScore);
                                                    Console.WriteLine("평균점수 : " + students[i].average);
                                                }
                                            }
                                        }
                                        else
                                            Console.WriteLine("없는 학생의 번호입니다.");
                                    }
                                    catch
                                    {
                                        Console.WriteLine("잘못입력하였습니다.");
                                    }
                                }
                            }
                            break;

                        case 4:
                            ModeFlag = 4;
                            students = Manage.StudentRead(students, ModeFlag);
                            if (students[0].name != null)
                            {
                                Manage.Sort(students);
                                Console.WriteLine();
                                Console.WriteLine("점수 순으로 석차를 출력합니다.");
                                Console.WriteLine();
                                Manage.Print(students);
                                Console.ReadLine();
                            }
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("잘못된 입력입니다!");
                    Console.ReadLine();
                }
            }
        }
    }

    public class Student
    {
        public string name, grade, grade1, address, hobby;
        public int KoreanScore, MathScore, EngScore, number, average;

        public int average1(int a, int b, int c)
        {
            int result = a + b + c;
            return result / 3;           
        }

        public void insert(Student student)
        {
            name = student.name;
            grade = student.grade;
            grade1 = student.grade1;
            address = student.address;
            hobby = student.hobby;
            KoreanScore = student.KoreanScore;
            EngScore = student.EngScore;
            MathScore = student.MathScore;
            number = student.number;
            average = student.average;
        }
    }

    static class Manage
    {
        public static void Print(Student[] students)
        {
            for(int i = 0; i < students.Length; i++)
            {
                if(students[i].number > 0)
                {
                    Console.WriteLine("이름 : " + students[i].name);
                    Console.WriteLine("학년 : " + students[i].grade);
                    Console.WriteLine("반 : " + students[i].grade1);
                    Console.WriteLine("번호 : " + students[i].number);
                    Console.WriteLine("주소 : " + students[i].address);
                    Console.WriteLine("취미 : " + students[i].hobby);
                    Console.WriteLine("국어점수 : " + students[i].KoreanScore);
                    Console.WriteLine("영어점수 : " + students[i].EngScore);
                    Console.WriteLine("수학점수 : " + students[i].MathScore);
                    Console.WriteLine("평균점수 : " + students[i].average);                  
                }
            }
            Console.ReadLine();
        }

        public static void Sort(Student[] student)
        {
            for(int i = 0; i < student.Length; i++)
            {
                for(int j = 0; j < student.Length; j++)
                {
                    if (student[j].average < student[i].average)
                        Swap(student[i], student[j]);
                }
            }
        }

        public static void Swap(Student a, Student b)
        {
            Student temp = new Student();
            temp.insert(b);
            b.insert(a);
            a.insert(temp);
        }

        public static void StudentWrite(Student[] student, int studentCount)
        {
            if (File.Exists(@"C:\Users\jin yeong\.vscode\csharp_project\StudentsManagement\Manage.xlsx"))
            {
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"C:\Users\jin yeong\.vscode\csharp_project\StudentsManagement\Manage.xlsx");
                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                xlWorkbook.Application.ActiveWorkbook.Saved = true;

                for(int i =0; i < studentCount; i++)
                {
                    xlWorksheet.Cells[xlWorksheet.UsedRange.Rows.Count + 1, 1] = student[i].name;
                    xlWorksheet.Cells[xlWorksheet.UsedRange.Rows.Count, 2] = student[i].grade;
                    xlWorksheet.Cells[xlWorksheet.UsedRange.Rows.Count, 3] = student[i].grade1;
                    xlWorksheet.Cells[xlWorksheet.UsedRange.Rows.Count, 4] = xlWorksheet.UsedRange.Rows.Count - 1; // 학생 번호
                    xlWorksheet.Cells[xlWorksheet.UsedRange.Rows.Count, 5] = student[i].address;
                    xlWorksheet.Cells[xlWorksheet.UsedRange.Rows.Count, 6] = student[i].hobby;
                    xlWorksheet.Cells[xlWorksheet.UsedRange.Rows.Count, 7] = student[i].KoreanScore;
                    xlWorksheet.Cells[xlWorksheet.UsedRange.Rows.Count, 8] = student[i].EngScore;
                    xlWorksheet.Cells[xlWorksheet.UsedRange.Rows.Count, 9] = student[i].MathScore;
                    xlWorksheet.Cells[xlWorksheet.UsedRange.Rows.Count, 10] = student[i].average;
                }
                xlWorkbook.Save();
                xlWorkbook.Close();
                xlWorkbook = null;
                if(xlApp != null)
                {
                    Process[] pProcess;
                    pProcess = Process.GetProcessesByName("Excel");
                    pProcess[0].Kill();
                }
            }

            else
            {
                Excel.Application xlApp = new Excel.Application();
                xlApp.Workbooks.Add();
                Excel._Worksheet workSheet = xlApp.ActiveSheet;
                workSheet.SaveAs(@"C:\Users\jin yeong\.vscode\csharp_project\StudentsManagement\Manage.xlsx");
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"C:\Users\jin yeong\.vscode\csharp_project\StudentsManagement\Manage.xlsx");
                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];               
                xlWorkbook.Application.ActiveWorkbook.Saved = true;

                xlWorksheet.Cells[1, 1] = "이름";
                xlWorksheet.Cells[1, 2] = "학년";
                xlWorksheet.Cells[1, 3] = "반";
                xlWorksheet.Cells[1, 4] = "번호";
                xlWorksheet.Cells[1, 5] = "주소";
                xlWorksheet.Cells[1, 6] = "취미";
                xlWorksheet.Cells[1, 7] = "국어점수";
                xlWorksheet.Cells[1, 8] = "영어점수";
                xlWorksheet.Cells[1, 9] = "수학점수";
                xlWorksheet.Cells[1, 10] = "평균점수";

                for(int i= 0; i <student.Length; i++)
                {
                    if(student[i].name != null)
                    {
                        xlWorksheet.Cells[i + 2, 1] = student[i].name;
                        xlWorksheet.Cells[i + 2, 2] = student[i].grade;
                        xlWorksheet.Cells[i + 2, 3] = student[i].grade1;
                        xlWorksheet.Cells[i + 2, 4] = xlWorksheet.UsedRange.Rows.Count - 1; 
                        xlWorksheet.Cells[i + 2, 5] = student[i].address;
                        xlWorksheet.Cells[i + 2, 6] = student[i].hobby;
                        xlWorksheet.Cells[i + 2, 7] = student[i].KoreanScore;
                        xlWorksheet.Cells[i + 2, 8] = student[i].EngScore;
                        xlWorksheet.Cells[i + 2, 9] = student[i].MathScore;
                        xlWorksheet.Cells[i + 2, 10] = student[i].average;
                    }
                }
                xlWorkbook.Save();
                xlWorkbook.Close();
                if (xlApp != null)
                {
                    Process[] pProcess;
                    pProcess = Process.GetProcessesByName("Excel");
                    pProcess[0].Kill();
                }
            }
        }


        public static Student[] StudentRead(Student[] student, int modeflag) // modeflag가 2가 아니면 출력을 하지 않기 위해 
        {
            if (File.Exists(@"C:\Users\jin yeong\.vscode\csharp_project\StudentsManagement\Manage.xlsx"))
            {
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"C:\Users\jin yeong\.vscode\csharp_project\StudentsManagement\Manage.xlsx");
                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;

                for (int i = 2; i < student.Length; i++)
                {
                    if (xlRange.Value != null)
                    {
                        try
                        {
                            xlRange = xlWorksheet.get_Range("A" + i);
                            student[i - 2].name = xlRange.Text;
                            xlRange = xlWorksheet.get_Range("B" + i);
                            student[i - 2].grade = xlRange.Text;
                            xlRange = xlWorksheet.get_Range("C" + i);
                            student[i - 2].grade1 = xlRange.Text;
                            xlRange = xlWorksheet.get_Range("E" + i);
                            student[i - 2].address = xlRange.Text;
                            xlRange = xlWorksheet.get_Range("F" + i);
                            student[i - 2].hobby = xlRange.Text;
                            xlRange = xlWorksheet.get_Range("G" + i);

                            xlRange = xlWorksheet.Cells[i, 4];
                            student[i - 2].number = (int)xlRange.Value;
                            xlRange = xlWorksheet.Cells[i, 7];
                            student[i - 2].KoreanScore = (int)xlRange.Value;
                            xlRange = xlWorksheet.Cells[i, 8];
                            student[i - 2].EngScore = (int)xlRange.Value;
                            xlRange = xlWorksheet.Cells[i, 9];
                            student[i - 2].MathScore = (int)xlRange.Value;
                            xlRange = xlWorksheet.Cells[i, 10];
                            student[i - 2].average = (int)xlRange.Value;
                        }
                        catch
                        {
                        }
                    }
                }

                if (modeflag == 2)
                {
                    Console.WriteLine("전체 학생 정보를 출력합니다.");
                    Console.WriteLine();
                    Manage.Print(student);
                }

                xlWorkbook.Close();
                if (xlApp != null)
                {
                    Process[] pProcess;
                    pProcess = Process.GetProcessesByName("Excel");
                    pProcess[0].Kill();
                }
            }
            else
            {
                Console.WriteLine("학생의 데이터 정보가 없습니다.");
                Console.ReadLine();
            }
            return student;
        }
    }
}
