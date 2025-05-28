using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab_3.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public IFormFile? UploadedFile { get; set; }

        public string? FileName { get; set; }
        public long FileSize { get; set; }
        public bool IsImage { get; set; }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (UploadedFile != null && UploadedFile.Length > 0)
            {
                var uploadFolder = "UploadedFiles";

                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                var filePath = Path.Combine(uploadFolder, UploadedFile.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await UploadedFile.CopyToAsync(stream);
                }

                FileName = UploadedFile.FileName;
                FileSize = UploadedFile.Length;

                var ext = Path.GetExtension(FileName).ToLower();
                IsImage = ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".gif";
            }

            return Page();
        }
    }
}
