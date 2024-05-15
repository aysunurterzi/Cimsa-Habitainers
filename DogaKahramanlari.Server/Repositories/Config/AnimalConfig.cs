using DogaKahramanlari.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DogaKahramanlari.Server.Repositories.Config
{
    public class AnimalConfig : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).IsRequired();

            builder.HasData(
                      new Animal()
                      {
                          Id = 1,
                          Name = "Maymun",
                          ImagesNormal = "/black-animals/black-monkey.png",
                          ImagesStatus1 = "/animals/monkey.png",
                          Content = "Merhaba! Ben bir maymunum. Ormanların neşeli ve maceraperest sakinlerinden biriyim. Dal dal gezinir, ağaçlarda sallanır ve meyveleri toplarım. Akıllı ve oyunbaz bir hayvanım. Maymun olmak harika! Ancak, maalesef çevre kirliliği bizi de etkiliyor. Ormanlarımızın yok olması ve yaşam alanlarımızın azalması, hayatımızı zorlaştırıyor. Lütfen doğamızı koruyalım, böylece biz ve diğer hayvanlar mutlu ve sağlıklı bir şekilde yaşayabiliriz. Teşekkürler!",
                          Key = 1,
                          Value = 2,
                          Status = 0
                      },
                      new Animal()
                      {
                          Id = 2,
                          Name = "Aslan",
                          ImagesNormal = "/black-animals/black-lion.png",
                          ImagesStatus1 = "/animals/lion.png",
                          Content = "Merhaba! Ben bir aslanım. Ben büyük ve güçlüyüm. Afrika'nın sıcak savanlarında yaşıyorum. Altın rengim ve muhteşem yelesim var. Kükreyişimle tanınırım ve avlarımı korurum. Ama maalesef çevre kirliliği bizi etkiliyor. Ormanlarımız yok ediliyor ve su kaynaklarımız kirleniyor. Lütfen doğamızı koruyalım, böylece biz ve diğer hayvanlar mutlu ve sağlıklı bir şekilde yaşayabiliriz. Teşekkürler!",
                          Key = 2,
                          Value = 6,
                          Status = 0
                      },
                       new Animal()
                       {
                           Id = 3,
                           Name = "Zürafa",
                           ImagesNormal = "/black-animals/black-giraffe.png",
                           ImagesStatus1 = "/animals/giraffe.png",
                           Content = "Merhaba! Ben bir zürafaım. Uzun boyum ve uzun boynumla tanınıyorum. Afrika'nın sıcak savanlarında yaşarım. Yüksek ağaçlardaki yaprakları severim. Zürafa olmak harika! Ancak, maalesef çevre kirliliği bizi etkiliyor. Ormanlarımız yok ediliyor ve yaşam alanlarımız azalıyor. Lütfen doğamızı koruyalım, böylece biz ve diğer hayvanlar mutlu ve sağlıklı bir şekilde yaşayabiliriz. Teşekkürler!",
                           Key = 3,
                           Value = 7,
                           Status = 0
                       },
                       new Animal()
                       {
                           Id = 4,
                           Name = "Baykuş",
                           ImagesNormal = "/black-animals/black-owl.png",
                           ImagesStatus1 = "/animals/owl.png",
                           Content = "Merhaba! Ben bir baykuşum. Geceleri uyanıkken diğer hayvanlar uyur. Sessizce uçarım ve hızla dönerim. En sevdiğim şey avlanmaktır. Baykuş olmak harika! Ancak, maalesef çevre kirliliği bizi etkiliyor. Hava kirliliği ve orman tahribatı bizim yaşamımızı zorlaştırıyor. Lütfen doğamızı koruyalım, böylece biz ve diğer hayvanlar mutlu ve sağlıklı bir şekilde yaşayabiliriz. Teşekkürler!",
                           Key = 4,
                           Value = 8,
                           Status = 0
                       },
                       new Animal()
                       {
                           Id = 5,
                           Name = "Tilki",
                           ImagesNormal = "/black-animals/black-fox.png",
                           ImagesStatus1 = "/animals/fox.png",
                           Content = "Merhaba! Ben bir tilkiyim. Hızlı ve çevik bir avcıyım. Gece avlanır, gündüz uyurum. Tilki olmak gerçekten heyecan verici! Ancak, insan etkinlikleri ve çevre kirliliği yaşam alanlarımızı tehdit ediyor. Ormanlarımız azalıyor ve doğal yaşamımızı sürdürebileceğimiz alanlar giderek daralıyor. Lütfen doğal yaşamı korumak için çaba gösterelim, böylece biz ve diğer orman sakinleri mutlu ve sağlıklı bir şekilde var olabiliriz. Teşekkürler!",
                           Key = 5,
                           Value = 2,
                           Status = 0
                       },
                       new Animal()
                       {
                           Id = 6,
                           Name = "Kunduz",
                           ImagesNormal = "/black-animals/black-beaver.png",
                           ImagesStatus1 = "/animals/beaver.png",
                           Content = "Merhaba! Ben bir sincapım. Neşeli ve enerjik bir hayvanım. Ormanların uyanık ve hızlı koşucusuyum. Ağaçlarda zıplayıp yiyeceklerimi toplarım. Sincap olmak harika! Ancak, maalesef çevre kirliliği bizi de etkiliyor. Ormanların yok olması ve kentlerin büyümesi yaşam alanlarımızı tehdit ediyor. Lütfen doğamızı koruyalım, böylece biz ve diğer hayvanlar mutlu ve sağlıklı bir şekilde yaşayabiliriz. Teşekkürler!",
                           Key = 6,
                           Value = 7,
                           Status = 0
                       },
                       new Animal()
                       {
                           Id = 7,
                           Name = "Tavşan",
                           ImagesNormal = "/black-animals/black-rabbit.png",
                           ImagesStatus1 = "/animals/rabbit.png",
                           Content = "Merhaba! Ben bir tavşanım. Sevimli ve çevik bir hayvanım. Genellikle çimenlerde ve ormanlarda yaşarım. Büyük kulaklarım ve hızlı koşmamla tanınırım. Havada zıplayarak sevimli tavırlar sergilerim. Havuçları çok severim! Tavşan olmak harika! Ancak, maalesef çevre kirliliği bizi de etkiliyor. Ormanların yok olması ve tarım alanlarının genişlemesi, yaşam alanlarımızı tehdit ediyor. Lütfen doğal yaşam alanlarımızı koruyalım, böylece biz ve diğer hayvanlar mutlu ve sağlıklı bir şekilde yaşayabiliriz. Teşekkürler!",
                           Key = 7,
                           Value = 3,
                           Status = 0
                       },
                       new Animal()
                       {
                           Id = 8,
                           Name = "Kedi",
                           ImagesNormal = "/black-animals/black-cat.png",
                           ImagesStatus1 = "/animals/cat.png",
                           Content = "Merhaba! Ben bir kediyim. Gizemli ve zarif bir hayvanım. Yumuşak tüylerim ve kuyruğumla tanınırım. Genellikle evlerde ve sokaklarda dolaşırım. Bağımsız ve meraklıyım. Yüksek yerlere tırmanmayı çok severim. Kedi olmak harika! Ancak, maalesef çevre kirliliği bizi de etkiliyor. Hava kirliliği ve kentsel gelişim, yaşam alanlarımızı daraltıyor. Lütfen doğamızı koruyalım, böylece biz ve diğer hayvanlar mutlu ve sağlıklı bir şekilde yaşayabiliriz. Teşekkürler!",
                           Key = 8,
                           Value = 7,
                           Status = 0
                       },
                       new Animal()
                       {
                           Id = 9,
                           Name = "Köpek",
                           ImagesNormal = "/black-animals/black-dog.png",
                           ImagesStatus1 = "/animals/dog.png",
                           Content = "Merhaba! Ben bir köpeğim. Sadık ve sevgi dolu bir arkadaşım. İnsanların en yakın dostlarından biriyim. Oyun oynamayı ve koşmayı çok severim. Sahibime koruyucu ve mutlu anlar yaşatırım. Köpek olmak harika! Ancak, maalesef çevre kirliliği bizi de etkiliyor. Kirlenmiş sular ve hava, sağlığımızı tehdit ediyor. Lütfen doğamızı koruyalım, böylece biz ve diğer hayvanlar mutlu ve sağlıklı bir şekilde yaşayabiliriz. Teşekkürler!",
                           Key = 9,
                           Value = 5,
                           Status = 0
                       },
                       new Animal()
                       {
                           Id = 10,
                           Name = "Flamingo",
                           ImagesNormal = "/black-animals/black-flamingo.png",
                           ImagesStatus1 = "/animals/flamingo.png",
                           Content = "Merhaba! Ben bir flamingoyum. Zarif ve renkli bir su kuşuyum, sığ sularda dans ederim. Uzun bacaklarım ve eşsiz gagamla sularda avlanırım. sulak alanların yok olması ve kirlenmesi bizi çok olumsuz etkiliyor. Bu durum, besin zincirimizi ve yaşam alanlarımızı tehdit ediyor. Lütfen su kaynaklarını korumak için çaba gösterelim, böylece biz ve diğer su kuşları mutlu ve sağlıklı bir şekilde yaşayabiliriz.",
                           Key = 10,
                           Value = 2,
                           Status = 0
                       },
                       new Animal()
                       {
                           Id = 11,
                           Name = "Geyik",
                           ImagesNormal = "/black-animals/black-reindeer.png",
                           ImagesStatus1 = "/animals/reindeer.png",
                           Content = "Merhaba! Ben bir geyiğim. Zarif ve sessiz bir orman sakinim, ormanların incisiyim. Uzun boynum ve güzel boynuzlarım ile doğanın güzelliğini temsil ederim. Geyik olmak gerçekten büyüleyici! Ancak, ormansızlaşma ve avlanma baskısı yaşam alanlarımızı tehdit ediyor. Bu nedenle, doğal habitatlarımızı korumak ve avlanma faaliyetlerini sınırlamak çok önemlidir. Lütfen doğal yaşamı korumak için çaba gösterelim, böylece biz ve diğer orman dostları mutlu ve sağlıklı bir şekilde yaşayabiliriz. Teşekkürler!",
                           Key = 11,
                           Value = 6,
                           Status = 0
                       },
                       new Animal()
                       {
                           Id = 12,
                           Name = "Kurbağa",
                           ImagesNormal = "/black-animals/black-frog.png",
                           ImagesStatus1 = "/animals/frog.png",
                           Content = "Merhaba! Ben bir kurbağayım. Geceleri nehirlerin, göllerin ve bataklıkların tadını çıkaran sevimli bir sakinim. Uzun ve yapışkan dilimle böcekleri yakalarım. Su altında yüzerken, şarkılarımı çalıp çırparken mutlu olurum. Kurbağa olmak harika! Ancak, maalesef çevre kirliliği bizi de etkiliyor. Su kaynaklarının kirlenmesi ve habitatlarımızın tahrip edilmesi, hayatımızı zorlaştırıyor. Lütfen doğamızı koruyalım, böylece biz ve diğer hayvanlar mutlu ve sağlıklı bir şekilde yaşayabiliriz. Teşekkürler!",
                           Key = 12,
                           Value = 8,
                           Status = 0
                       },
                       new Animal()
                       {
                           Id = 13,
                           Name = "Papağan",
                           ImagesNormal = "/black-animals/black-parrot.png",
                           ImagesStatus1 = "/animals/parrot.png",
                           Content = "Merhaba! Ben bir papağanım. Renkli ve konuşkan bir kuşum. Genellikle tropikal ormanlarda ve evlerde yaşarım. Parlak tüylerim ve çeşitli seslerimle dikkat çekerim. İnsanların taklit ettiğim seslerini öğrenirim. Papağan olmak harika! Ancak, maalesef çevre kirliliği bizi de etkiliyor. Ormanların yok olması ve yasadışı avlanma, yaşam alanlarımızı tehdit ediyor. Lütfen doğal yaşam alanlarımızı koruyalım, böylece biz ve diğer hayvanlar mutlu ve sağlıklı bir şekilde yaşayabiliriz. Teşekkürler!",
                           Key = 13,
                           Value = 3,
                           Status = 0
                       }
                );
        }
    }
}