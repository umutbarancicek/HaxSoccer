# ⚽ HaxSoccer

*Advanced 3D Soccer simulation engine featuring custom physics-based mechanics, modular architecture, and procedural animation built for Unity.*

![Unity](https://img.shields.io/badge/Unity-2022.3%2B-black?style=for-the-badge&logo=unity)
![C#](https://img.shields.io/badge/C%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![License](https://img.shields.io/badge/License-MIT-yellow.svg?style=for-the-badge)
![Status](https://img.shields.io/badge/Status-In_Development-orange.svg?style=for-the-badge)

---

## 📖 Hakkında

**HaxSoccer**, Unity ekosistemi için geliştirilmiş, yüksek performanslı ve fizik tabanlı bir futbol simülasyon motorudur. Standart oyun mekaniklerinin ötesine geçerek, topun aerodinamik hareketlerinden oyuncuların prosedürel animasyonlarına kadar her detayı kontrol etmenize olanak tanır. 

Modüler yapısı sayesinde hem arcade tarzı hızlı oyunlar hem de derinlemesine simülasyon projeleri için esnek bir temel sunar.

## ✨ Özellikler

- **Gelişmiş Fizik Motoru:** Top için özel Magnus etkisi (kavis verme), sürtünme ve sekme dinamikleri.
- **Modüler Mimari:** SOLID prensiplerine uygun, kolayca genişletilebilir takım ve oyuncu sistemleri.
- **Prosedürel Animasyon:** IK (Inverse Kinematics) destekli, topa temas anında dinamik olarak şekillenen oyuncu hareketleri.
- **Gelişmiş Kontrol Sistemi:** Hassas top sürme, pas verme ve şut mekanikleri için özelleştirilmiş Input sistemi.
- **Esnek Yapılandırma:** Topun ağırlığından sahanın sürtünme katsayısına kadar her şeyi ScriptableObjects ile yönetme imkanı.

## 🛠 Teknolojiler

- **Motor:** [Unity 2022.3+](https://unity.com/)
- **Dil:** C# (.NET Standard 2.1)
- **Render Pipeline:** URP (Universal Render Pipeline)
- **Fizik:** Unity Physics & Custom Physics Solvers

## 🚀 Kurulum

Projeyi yerel makinenizde çalıştırmak için şu adımları izleyin:

1. Depoyu klonlayın:
   ```bash
   git clone https://github.com/umutbarancicek/HaxSoccer.git
   ```

2. **Unity Hub**'ı açın ve projeyi listeye ekleyin.
3. Unity **2022.3** veya daha yeni bir sürümle projeyi başlatın.
4. Gerekli bağımlılıkların (Package Manager) yüklenmesini bekleyin.

## 🕹 Kullanım

Simülasyonu başlatmak ve temel bileşenleri incelemek için:

1. `Assets/Scenes/Main.unity` sahnesini açın.
2. `SoccerManager` objesi üzerinden oyun kurallarını (süre, skor vb.) belirleyin.
3. Kendi oyuncu prefab'ınızı oluşturmak için `IControllable` arayüzünü (interface) implemente edin:

```csharp
public class MyPlayerController : MonoBehaviour, IControllable {
    public void Kick(Vector3 direction, float force) {
        // Özel şut mantığınızı buraya yazın
    }
}
```

## 🤝 Katkıda Bulunma

Katkılarınızı bekliyoruz! Projeyi geliştirmek için:

1. Bu depoyu Fork'layın.
2. Yeni bir özellik dalı (branch) oluşturun (`git checkout -b feature/YeniOzellik`).
3. Değişikliklerinizi Commit edin (`git commit -m 'Yeni özellik eklendi'`).
4. Dalınızı Push edin (`git push origin feature/YeniOzellik`).
5. Bir **Pull Request** oluşturun.

## 📄 Lisans

Bu proje **MIT Lisansı** altında lisanslanmıştır. Detaylar için [LICENSE](LICENSE) dosyasına göz atabilirsiniz.

---

**Geliştirici:** [@umutbarancicek](https://github.com/umutbarancicek)  
**İletişim:** Proje ile ilgili sorularınız için Issue oluşturabilir veya iletişime geçebilirsiniz.
