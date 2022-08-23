namespace Client.Models.Constants
{
    public static class Messages
    {
        public static class Entity 
        {
            public static readonly string Added = "Varlık başarıyla eklendi";        
            public static readonly string NotAdded = "Varlık eklenemedi";
            public static readonly string Deleted = "Varlık başarıyla silindi";
            public static readonly string NotDeleted = "Varlık silinemedi";
            public static readonly string Updated = "Varlık başarıyla güncellendi";
            public static readonly string NotUpdated = "Varlık güncellenemedi";
            public static readonly string Found = "Varlık başarıyla bulundu";
            public static readonly string NotFound = "Varlık bulunamadı";
        }

        public static class Auth
        {
            public static readonly string UserNotFound = "Kullanıcı bulunamadı";
            public static readonly string PasswordError = "Şifre hatalı";
            public static readonly string SuccessfulLogin="Sisteme giriş başarılı";
            public static readonly string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
            public static readonly string UserRegistered = "Kullanıcı başarıyla kaydedildi";
            public static readonly string UserRegisteredFailed = "Kullanıcı başarıyla kaydedildi";
            public static readonly string AccessTokenCreated="Access token başarıyla oluşturuldu";
        }

        public static class Validation
        {
            public static readonly string Failed = "Validasyon hatası";
        }



    }
}