using DeSjoerd.Competition.ActionObjectives.Models;
using DeSjoerd.Competition.Models;
using Orchard.ContentManagement;
using Orchard.Media.Services;
using Orchard.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeSjoerd.Competition.ActionObjectives.Extensions;
using System.IO;
using Orchard.Autoroute.Services;
using System.Drawing;
using System.Drawing.Imaging;

namespace DeSjoerd.Competition.ActionObjectives.Services
{
    public class PhotoSubmitService : IPhotoSubmitService
    {
        private readonly IMediaService _mediaService;
        private readonly IActionSubmitService _actionSubmitService;
        private readonly IContentManager _contentManager;
        private readonly ISlugService _slugService;

        public PhotoSubmitService(
            IMediaService mediaService,
            IActionSubmitService actionSubmitService,
            IContentManager contentManager,
            ISlugService slugService)
        {
            _mediaService = mediaService;
            _actionSubmitService = actionSubmitService;
            _contentManager = contentManager;
            _slugService = slugService;
        }

        public void SubmitPhoto(ObjectivePart objective, TeamPart team, HttpPostedFileBase photo)
        {
            Argument.ThrowIfNull(objective, "objective");
            Argument.ThrowIfNull(team, "team");
            Argument.ThrowIfNull(photo, "photo");

            var path = Path.Combine("Submits", _slugService.Slugify(team.Title), _slugService.Slugify(objective.Title));

            var guid = Guid.NewGuid().ToString();
            var extension = photo.FileName.Split('.').LastOrDefault() ?? string.Empty;

            string publicUrl = null;
            var succesfull = true;
            try
            {
                using (Image img = Image.FromStream(photo.InputStream))
                {
                    double ratio = img.Height > 1024 ? 1024.0 / img.Height : 1.0;
                    int height = (int)(ratio * img.Height);
                    int width = (int)(ratio * img.Width);
                    using (Bitmap bitmap = new Bitmap(img, width, height))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            bitmap.Save(memoryStream, ImageFormat.Jpeg);
                            memoryStream.Position = 0;

                            publicUrl = _mediaService.UploadMediaFile(path, string.Format("{0}.{1}", guid, ".jpg"), memoryStream, false);
                        }
                    }
                }
            }
            catch (Exception)
            {
                succesfull = false;
            }
            if (succesfull)
            {
                var newSubmit = _actionSubmitService.NewActionSubmit<PhotoSubmitPart>(objective, team, "PhotoSubmit");
                newSubmit.PhotoUrl = publicUrl;
                _contentManager.Create(newSubmit);
            }
        }
    }
}