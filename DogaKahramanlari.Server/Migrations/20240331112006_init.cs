using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DogaKahramanlari.Server.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagesNormal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagesStatus1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Key = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Duties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DutyStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    DateStatus = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserKeys",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NumberOfKeys = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserKeys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Content", "ImagesNormal", "ImagesStatus1", "Key", "Name", "Status", "Value" },
                values: new object[,]
                {
                    { 1, "Merhaba! Ben bir maymunum. Ormanların neşeli ve maceraperest sakinlerinden biriyim. Dal dal gezinir, ağaçlarda sallanır ve meyveleri toplarım. Akıllı ve oyunbaz bir hayvanım. Maymun olmak harika! Ancak, maalesef çevre kirliliği bizi de etkiliyor. Ormanlarımızın yok olması ve yaşam alanlarımızın azalması, hayatımızı zorlaştırıyor. Lütfen doğamızı koruyalım, böylece biz ve diğer hayvanlar mutlu ve sağlıklı bir şekilde yaşayabiliriz. Teşekkürler!", "/black-animals/black-monkey.png", "/animals/monkey.png", 1, "Maymun", 0, 2 },
                    { 2, "Merhaba! Ben bir aslanım. Ben büyük ve güçlüyüm. Afrika'nın sıcak savanlarında yaşıyorum. Altın rengim ve muhteşem yelesim var. Kükreyişimle tanınırım ve avlarımı korurum. Ama maalesef çevre kirliliği bizi etkiliyor. Ormanlarımız yok ediliyor ve su kaynaklarımız kirleniyor. Lütfen doğamızı koruyalım, böylece biz ve diğer hayvanlar mutlu ve sağlıklı bir şekilde yaşayabiliriz. Teşekkürler!", "/black-animals/black-lion.png", "/animals/lion.png", 2, "Aslan", 0, 6 },
                    { 3, "Merhaba! Ben bir zürafaım. Uzun boyum ve uzun boynumla tanınıyorum. Afrika'nın sıcak savanlarında yaşarım. Yüksek ağaçlardaki yaprakları severim. Zürafa olmak harika! Ancak, maalesef çevre kirliliği bizi etkiliyor. Ormanlarımız yok ediliyor ve yaşam alanlarımız azalıyor. Lütfen doğamızı koruyalım, böylece biz ve diğer hayvanlar mutlu ve sağlıklı bir şekilde yaşayabiliriz. Teşekkürler!", "/black-animals/black-giraffe.png", "/animals/giraffe.png", 3, "Zürafa", 0, 7 },
                    { 4, "Merhaba! Ben bir baykuşum. Geceleri uyanıkken diğer hayvanlar uyur. Sessizce uçarım ve hızla dönerim. En sevdiğim şey avlanmaktır. Baykuş olmak harika! Ancak, maalesef çevre kirliliği bizi etkiliyor. Hava kirliliği ve orman tahribatı bizim yaşamımızı zorlaştırıyor. Lütfen doğamızı koruyalım, böylece biz ve diğer hayvanlar mutlu ve sağlıklı bir şekilde yaşayabiliriz. Teşekkürler!", "/black-animals/black-owl.png", "/animals/owl.png", 4, "Baykuş", 0, 8 },
                    { 5, "Merhaba! Ben bir tilkiyim. Hızlı ve çevik bir avcıyım. Gece avlanır, gündüz uyurum. Tilki olmak gerçekten heyecan verici! Ancak, insan etkinlikleri ve çevre kirliliği yaşam alanlarımızı tehdit ediyor. Ormanlarımız azalıyor ve doğal yaşamımızı sürdürebileceğimiz alanlar giderek daralıyor. Lütfen doğal yaşamı korumak için çaba gösterelim, böylece biz ve diğer orman sakinleri mutlu ve sağlıklı bir şekilde var olabiliriz. Teşekkürler!", "/black-animals/black-fox.png", "/animals/fox.png", 5, "Tilki", 0, 2 },
                    { 6, "Merhaba! Ben bir sincapım. Neşeli ve enerjik bir hayvanım. Ormanların uyanık ve hızlı koşucusuyum. Ağaçlarda zıplayıp yiyeceklerimi toplarım. Sincap olmak harika! Ancak, maalesef çevre kirliliği bizi de etkiliyor. Ormanların yok olması ve kentlerin büyümesi yaşam alanlarımızı tehdit ediyor. Lütfen doğamızı koruyalım, böylece biz ve diğer hayvanlar mutlu ve sağlıklı bir şekilde yaşayabiliriz. Teşekkürler!", "/black-animals/black-beaver.png", "/animals/beaver.png", 6, "Kunduz", 0, 7 },
                    { 7, "Merhaba! Ben bir tavşanım. Sevimli ve çevik bir hayvanım. Genellikle çimenlerde ve ormanlarda yaşarım. Büyük kulaklarım ve hızlı koşmamla tanınırım. Havada zıplayarak sevimli tavırlar sergilerim. Havuçları çok severim! Tavşan olmak harika! Ancak, maalesef çevre kirliliği bizi de etkiliyor. Ormanların yok olması ve tarım alanlarının genişlemesi, yaşam alanlarımızı tehdit ediyor. Lütfen doğal yaşam alanlarımızı koruyalım, böylece biz ve diğer hayvanlar mutlu ve sağlıklı bir şekilde yaşayabiliriz. Teşekkürler!", "/black-animals/black-rabbit.png", "/animals/rabbit.png", 7, "Tavşan", 0, 3 },
                    { 8, "Merhaba! Ben bir kediyim. Gizemli ve zarif bir hayvanım. Yumuşak tüylerim ve kuyruğumla tanınırım. Genellikle evlerde ve sokaklarda dolaşırım. Bağımsız ve meraklıyım. Yüksek yerlere tırmanmayı çok severim. Kedi olmak harika! Ancak, maalesef çevre kirliliği bizi de etkiliyor. Hava kirliliği ve kentsel gelişim, yaşam alanlarımızı daraltıyor. Lütfen doğamızı koruyalım, böylece biz ve diğer hayvanlar mutlu ve sağlıklı bir şekilde yaşayabiliriz. Teşekkürler!", "/black-animals/black-cat.png", "/animals/cat.png", 8, "Kedi", 0, 7 },
                    { 9, "Merhaba! Ben bir köpeğim. Sadık ve sevgi dolu bir arkadaşım. İnsanların en yakın dostlarından biriyim. Oyun oynamayı ve koşmayı çok severim. Sahibime koruyucu ve mutlu anlar yaşatırım. Köpek olmak harika! Ancak, maalesef çevre kirliliği bizi de etkiliyor. Kirlenmiş sular ve hava, sağlığımızı tehdit ediyor. Lütfen doğamızı koruyalım, böylece biz ve diğer hayvanlar mutlu ve sağlıklı bir şekilde yaşayabiliriz. Teşekkürler!", "/black-animals/black-dog.png", "/animals/dog.png", 9, "Köpek", 0, 5 },
                    { 10, "Merhaba! Ben bir flamingoyum. Zarif ve renkli bir su kuşuyum, sığ sularda dans ederim. Uzun bacaklarım ve eşsiz gagamla sularda avlanırım. sulak alanların yok olması ve kirlenmesi bizi çok olumsuz etkiliyor. Bu durum, besin zincirimizi ve yaşam alanlarımızı tehdit ediyor. Lütfen su kaynaklarını korumak için çaba gösterelim, böylece biz ve diğer su kuşları mutlu ve sağlıklı bir şekilde yaşayabiliriz.", "/black-animals/black-flamingo.png", "/animals/flamingo.png", 10, "Flamingo", 0, 2 },
                    { 11, "Merhaba! Ben bir geyiğim. Zarif ve sessiz bir orman sakinim, ormanların incisiyim. Uzun boynum ve güzel boynuzlarım ile doğanın güzelliğini temsil ederim. Geyik olmak gerçekten büyüleyici! Ancak, ormansızlaşma ve avlanma baskısı yaşam alanlarımızı tehdit ediyor. Bu nedenle, doğal habitatlarımızı korumak ve avlanma faaliyetlerini sınırlamak çok önemlidir. Lütfen doğal yaşamı korumak için çaba gösterelim, böylece biz ve diğer orman dostları mutlu ve sağlıklı bir şekilde yaşayabiliriz. Teşekkürler!", "/black-animals/black-reindeer.png", "/animals/reindeer.png", 11, "Geyik", 0, 6 },
                    { 12, "Merhaba! Ben bir kurbağayım. Geceleri nehirlerin, göllerin ve bataklıkların tadını çıkaran sevimli bir sakinim. Uzun ve yapışkan dilimle böcekleri yakalarım. Su altında yüzerken, şarkılarımı çalıp çırparken mutlu olurum. Kurbağa olmak harika! Ancak, maalesef çevre kirliliği bizi de etkiliyor. Su kaynaklarının kirlenmesi ve habitatlarımızın tahrip edilmesi, hayatımızı zorlaştırıyor. Lütfen doğamızı koruyalım, böylece biz ve diğer hayvanlar mutlu ve sağlıklı bir şekilde yaşayabiliriz. Teşekkürler!", "/black-animals/black-frog.png", "/animals/frog.png", 12, "Kurbağa", 0, 8 },
                    { 13, "Merhaba! Ben bir papağanım. Renkli ve konuşkan bir kuşum. Genellikle tropikal ormanlarda ve evlerde yaşarım. Parlak tüylerim ve çeşitli seslerimle dikkat çekerim. İnsanların taklit ettiğim seslerini öğrenirim. Papağan olmak harika! Ancak, maalesef çevre kirliliği bizi de etkiliyor. Ormanların yok olması ve yasadışı avlanma, yaşam alanlarımızı tehdit ediyor. Lütfen doğal yaşam alanlarımızı koruyalım, böylece biz ve diğer hayvanlar mutlu ve sağlıklı bir şekilde yaşayabiliriz. Teşekkürler!", "/black-animals/black-parrot.png", "/animals/parrot.png", 13, "Papağan", 0, 3 }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "15f7ec80-d12e-4b00-8415-8dab0b8f0950", null, "Teacher", "TEACHER" });

            migrationBuilder.InsertData(
                table: "Duties",
                columns: new[] { "Id", "Content", "DateStatus", "DutyStatus" },
                values: new object[,]
                {
                    { 1, "Su tasarrufu yapmak: Dişlerimizi fırçalarken suyu kapatmayı unutmayalım. Bu sayede gereksiz yere su israfını önlemiş olacağız.", (byte)0, (byte)0 },
                    { 2, "Geri dönüşüm yapmak: \"Bugün evdeki atık malzemeleri, plastik, kağıt, cam veya metal gibi kategorilere ayıralım. Böylelikle geri dönüşüme katkı sağlamış olacağız.", (byte)0, (byte)0 },
                    { 3, "Enerji Tasarrufu yapmak: \"Herhangi bir odadan çıktığımızda ışıkları kapatmayı unutmayalım. Böylelikle elektrik tasarrufu yapmış olacağız.", (byte)0, (byte)0 },
                    { 4, "Bitki sulamak: \"Bitkiler de bizim gibi canlı varlıklardır ve yaşamlarını sürdürmek için suya ihtiyaç duyarlar. Bugün onlara biraz sevgi ve su verelim.", (byte)0, (byte)0 },
                    { 5, "Hayvanları beslemek: \"Hadi bugün sokak hayvanları için mama kabı ve su kabı hazırlayalım. Hazırladığımız kapları onların yaşam alanlarına yakın bir yere bırakalım.", (byte)0, (byte)0 },
                    { 6, "Çöp toplamak: \"Bugün çevremizi temizleyelim! Yürürken karşılaştığımız etrafımızdaki çöpleri toplayıp çöp kutusuna atalım. Bu sayede hem doğayı hem de çevremizi temiz tutmuş olacağız.", (byte)0, (byte)0 },
                    { 7, "Gıda israfını azaltmak: \"Bugünkü görevin, yemeklerini bitirebileceğin kadarını tabağına almak. Bu sayede kalan yemeklerin çöpe gitmesini engel olmuş olacağız.", (byte)0, (byte)0 },
                    { 8, "Hayvan fotoğrafı çekmek: \"Bugün bir hayvan dostumuzun fotoğrafını çekelim. O hayvan hakkında bilgilendirici bilgileri öğrenip arkadaşlarımızla paylaşalım.", (byte)0, (byte)0 },
                    { 9, "Ağaç dikmek: \"Hadi birlikte doğayı korumak için bir ağaç veya fidan dikelim. Daha sonra o fidanı sulayalım ve fidanın büyüyüp gelişmesini gözlemleyelim.", (byte)1, (byte)0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Duties");

            migrationBuilder.DropTable(
                name: "UserKeys");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
