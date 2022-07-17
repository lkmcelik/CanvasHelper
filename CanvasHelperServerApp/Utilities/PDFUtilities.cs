using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using CanvasHelperServerApp.Models;
using System.Collections.Generic;

namespace CanvasHelperServerApp.Utilities
{
    public static class PDFUtilities
    {
        public static byte[] GeneratePDFData(User marker, User student, Assignment assignment)
        {
            var stream = new MemoryStream();
            var writer = new PdfWriter(stream);
            var pdf = new PdfDocument(writer);
            var document = new Document(pdf);

            Text title = new(assignment.Name + " - Feedback");
            title.SetFontSize(20);
            Paragraph titleParagraph = new();
            titleParagraph.Add(title);
            document.Add(titleParagraph);

            document.Add(new Paragraph("Module: " + assignment.IdCourseNavigation.Name));
            document.Add(new Paragraph("Student: " + student.FirstName + " " + student.LastName));
            document.Add(new Paragraph("Marker: " + marker.FirstName + " " + marker.LastName));

            int totalMarksEarned = 0;
            int totalMarksPossible = 0;

            List<Criterion> criteria = new List<Criterion>(assignment.Criteria);

            foreach (Criterion c in criteria)
            {
                List<UsersCriteriaFeedback> ucfs = new(c.UsersCriteriaFeedbacks);
                var feedbackText = "";
                int criterionMarks = 0;
                if (ucfs.Count > 0)
                {
                    Feedback f = ucfs[0].IdFeedbackNavigation;
                    feedbackText = f.Text;
                    criterionMarks = (int) f.Mark;
                }
                var criterion1Name = c.Name;
                
                int criterionMaximumMarks = (int) c.MaxMark;

                totalMarksEarned += criterionMarks;
                totalMarksPossible += criterionMaximumMarks;

                Paragraph feedback1Paragrah = new();
                Text criterionText = new(criterion1Name);
                criterionText.SetBold();
                feedback1Paragrah.Add(criterionText);
                document.Add(feedback1Paragrah);
                document.Add(new Paragraph(feedbackText));
                document.Add(new Paragraph("Marks: " + criterionMarks + "/" + criterionMaximumMarks));
            }
            document.Add(new Paragraph("Total marks: " + totalMarksEarned + "/" + totalMarksPossible));

            /*
            Text overallCommentsHeader = new("Overall comments");
            overallCommentsHeader.SetBold();
            overallCommentsHeader.SetFontSize(16);
            Paragraph overallCommentsParagraph = new();
            overallCommentsParagraph.Add(overallCommentsHeader);
            document.Add(overallCommentsParagraph);
            var overallComments = "Overall, good work.";
            document.Add(new Paragraph(overallComments));
            */

            document.Close();
            byte[] result = stream.ToArray();
            return result;
        }
    }
}
