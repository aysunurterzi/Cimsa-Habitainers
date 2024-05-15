import { faLock } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import "./style.css";

const AnimalsInCages = () => {
  const [selectedAnimal, setSelectedAnimal] = useState(null);
  const [isPopupOpen, setPopupOpen] = useState(false);
  const [isSecondPopupOpen, setSecondPopupOpen] = useState(false);
  const [keyNumber, setKeyNumber] = useState(null);
  const [insufficientKeys, setInsufficientKeys] = useState(false);
  const [currentPage, setCurrentPage] = useState(1);
  const [animals, setAnimals] = useState([]);
  const [popupTitle, setPopupTitle] = useState("");
  const [popupContent, setPopupContent] = useState("");
  const [userId, setUserId] = useState(localStorage.getItem('userId'));

  const animalsPerPage = 12;
  const titles = [
    "Bir Yeni Arkadaş Kazandın!",
    "Harika! Yepyeni Bir Macera Başlıyor!",
    "Sevimli Dostuna Kavuştun!",
    "Muhteşem İş! Hayvanları Kurtarmaya Devam Ediyoruz!",
    "Süper Kahramanlık Gösterisi! İşte Yeni Dostun!",
    "Arkadaşlığın Başlangıcı: Bir Hayvan Daha Özgür!",
  ];
  const contents = [
    "Efsanevi! Yepyeni bir arkadaş kazandın! Haydi, onunla tanış, oyunlar oyna ve birlikte eğlenin. Arkadaşlık her zaman en güzel maceraları getirir!",
    "Muhteşem! Harika bir iş başardın! Şimdi sıra yeni dostunla eğlenmekte. Ona sevgi ve neşe getir, birlikte büyük bir maceraya atılın!",
    "Tatlı bir sürpriz! Sevimli dostuna kavuştun! Artık birlikte oyun oynayabilir, maceralara atılabilir ve birbirinizi keşfedebilirsiniz. Ne harika bir gün!",
    "Heyecan verici! Hayvanları kurtarmaya devam ediyoruz! Yeni arkadaşların, yeni maceraların başlangıcı! Birlikte her şeyi başarabiliriz. Yola devam!",
    "Süper kahramanlık gösterisi! İşte yeni dostun! Birlikte dünyayı daha güzel bir yer yapmak için yola çıktık. Eğlence dolu anlar sizi bekliyor!",
    "Muhteşem bir başarı! Bir hayvan daha özgürlüğüne kavuştu ve arkadaşlık başladı! Ona sevgiyle bakmayı unutma, birlikte muhteşem maceralara atılacağız!",
  ];



  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch("http://localhost:5120/api/animals");
        const data = await response.json();
        setAnimals(data);
      } catch (error) {
        console.error("Error fetching animals:", error);
      }
    };

    fetchData();
  }, []);


  const GetKeyNumber = async () => {
    try {
      const response = await fetch(`http://localhost:5120/api/userKeys/${userId}`);
      if (!response.ok) {
        throw new Error('Failed to fetch data');
      }
      const data = await response.json();
      console.log(data.numberOfKeys);
      setKeyNumber(data.numberOfKeys);
    } catch (error) {
      console.error('Error fetching data:', error);
    }
  };

  useEffect(() => {
    // Anahtar sayısını güncelleme
    GetKeyNumber();
  }, []);



  const indexOfLastAnimal = currentPage * animalsPerPage;
  const indexOfFirstAnimal = indexOfLastAnimal - animalsPerPage;
  const currentAnimals = animals.slice(indexOfFirstAnimal, indexOfLastAnimal);
  const paginate = (pageNumber) => setCurrentPage(pageNumber);

  const openPopup = (animal) => {
    setSelectedAnimal(animal);
    if (keyNumber >= animal.value) {
      setPopupOpen(true);
    } else {
      setInsufficientKeys(true);
      setTimeout(() => setInsufficientKeys(false), 1000);
    }
  };

  const closePopup = () => {
    setSelectedAnimal(null);
    setPopupOpen(false);
  };

  const updateKeys = (value) => {
    setKeyNumber((prevKeyNumber) => Math.max(prevKeyNumber - value, 0));
  };

  const rescueAnimal = async () => {
    const updatedAnimals = animals.map((animal) =>
      animal.id === selectedAnimal.id ? { ...animal, status: 1 } : animal
    );
  
    setAnimals(updatedAnimals); // Update the state with the updated status
  
    fetch(`http://localhost:5120/api/animals/${selectedAnimal.id}`, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({
        ...selectedAnimal,
        status: 1 // Change the status to 1 when rescued
      })
    })
    .then(response => {
      if (!response.ok) {
        throw new Error('Failed to update animal status');
      }
      return response.json();
    })
    .then(data => {
      console.log('Animal status updated successfully:', data);
      // Reload the page to reflect the changes
      window.location.reload();
    })
    .catch(error => {
      console.error('Error updating animal status:', error);
    });
  
    setPopupOpen(false);


    try {



      const url = `http://localhost:5120/api/userKeys/${userId}`;
      const newData = {
        id: userId,
        numberOfKeys: keyNumber - selectedAnimal.value

      };
      console.log(keyNumber);
      const response = await fetch(url, {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(newData)
      });
      if (response.ok) {
        console.log('User keys updated successfully.');
      } else {
        console.error('Failed to update user keys.');
      }
    } catch (error) {
      console.error('Error updating user keys:', error);
    }

    GetKeyNumber();


  };

  return (
    <div>

      <button id="task" onClick={() => navigate("/tasks")}></button>
      <button id="forest" onClick={() => navigate("/forest")}></button>
      <button id="dashboard" onClick={() => navigate("/dashboard")}></button>
      <button id="logout" onClick={() => navigate("/")}></button>


      <div className="header">
        <h1>HAYVANLAR
        <h1>HAYVANLAR</h1>
        </h1>
       
   </div>
   <br></br>
    <br></br>

      <div className="container">
        <div id="holder">
          <div id="text">
            <h1>Kurtarmak istediğiniz hayvanın kafesine tıklayın.</h1>
          </div>
          <div id="key">
            <div id="keyIcon">
              <img src="/icon/keyIcon.png" alt="Key Icon" />
            </div>
            <div id="keyNumber">{keyNumber}</div>
          </div>
        </div>
        <div id="animal-grid">
          {currentAnimals.map((animal) => (
            <div className="animal" key={animal.id}>
              <img
                className="animal-image"
                src={
                  animal.status === 1
                    ? animal.imagesStatus1
                    : animal.imagesNormal
                }
                alt={animal.name}
              />
              {!animal.status && (
                <>
                  <img src="/animals/cage.png" className="cage" />
                  <button
                    id="keyOpen"
                    onClick={() => openPopup(animal)}
                    style={{ display: "flex", alignItems: "center" }}
                  >
                    <FontAwesomeIcon icon={faLock} />
                    <span style={{ marginLeft: "5px" }}>/</span>
                    <span style={{ marginLeft: "5px" }}>{animal.value}</span>
                  </button>
                </>
              )}
            </div>
          ))}
        </div>

        {isPopupOpen && selectedAnimal && (
          <div className="popup">
            <div className="popup-content">
              <h2>{selectedAnimal.name}</h2>
              <img
                src={
                  selectedAnimal.status === 1
                    ? selectedAnimal.imagesStatus1
                    : selectedAnimal.imagesNormal
                }
                alt={selectedAnimal.name}
              />
              <p>{selectedAnimal.content}</p>
              <button style={{ marginLeft: "5px" }} onClick={rescueAnimal}>
                Kurtar
              </button>
              <button id="close" style={{ marginLeft: "5px" }} onClick={closePopup}>
                Kapat
              </button>
            </div>
          </div>
        )}
        {isSecondPopupOpen && selectedAnimal && (
          <div className="second-popup">
            <div className="popup-content">
              <h2>{popupTitle}</h2>

              <img
                src={selectedAnimal.imagesStatus1}
                alt={selectedAnimal.name}
              />
              <p id="happyContent">
                <em>{popupContent}</em>
              </p>

              <button id="close" onClick={closeSecondPopup}>Kapat</button>
            </div>
          </div>
        )}


        {insufficientKeys && (
          <div className="custom-alert">
            <p>
              Yetersiz anahtar sayısı. Daha fazla anahtar kazanmak için
              görevleri yerine getirin.
            </p>
          </div>
        )}

        <div className="pagination">
          {currentPage > 1 && (
            <button onClick={() => paginate(currentPage - 1)}>&lt; </button>
          )}

          {Array.from(
            { length: Math.ceil(animals.length / animalsPerPage) },
            (_, index) => (
              <button key={index + 1} onClick={() => paginate(index + 1)}>
                {index + 1}
              </button>
            )
          )}

          {currentPage < Math.ceil(animals.length / animalsPerPage) && (
            <button onClick={() => paginate(currentPage + 1)}> &gt;</button>
          )}
        </div>
      </div>
    </div>
  );
};

export default AnimalsInCages;
