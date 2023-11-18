namespace WebAPI.Extensions
{
    public static class ConverterExtensions
    {
        public static DAL.Models.Installation ConvertToInstallation(this WebAPI.Models.InstallationM installation)
        {
            return new DAL.Models.Installation
            {
                Id = installation.Id,
                Description = installation.Description,
                Image = installation.Image,
                Street = installation.Street,
                No = installation.No,
                PostCode = installation.PostCode,
                City = installation.City,
                CoordinateX = installation.CoordinateX,
                CoordinateY = installation.CoordinateY,
                AzimutOrientation = installation.AzimutOrientation,
                TiltOrientation = installation.TiltOrientation,
                EnergyType = installation.EnergyType,
                IntegrationType = installation.IntegrationType,
                CellsType = installation.CellsType,
                Length = installation.Length,
                Width = installation.Width

            };
        }

        public static WebAPI.Models.InstallationM ConvertToInstallationM(this DAL.Models.Installation installation)
        {
            return new WebAPI.Models.InstallationM
            {
                Id = installation.Id,
                Description = installation.Description,
                Image = installation.Image,
                Street = installation.Street,
                No = installation.No,
                PostCode = installation.PostCode,
                City = installation.City,
                CoordinateX = installation.CoordinateX,
                CoordinateY = installation.CoordinateY,
                AzimutOrientation = installation.AzimutOrientation,
                TiltOrientation = installation.TiltOrientation,
                EnergyType = installation.EnergyType,
                IntegrationType = installation.IntegrationType,
                CellsType = installation.CellsType,
                Length = installation.Length,
                Width = installation.Width
            };
        }
    }
}