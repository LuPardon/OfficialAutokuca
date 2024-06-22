import React from "react";
import KarticaVozilo from "../components/KarticaVozilo";

const SvaVozila = () => {
  const [vozila, setVozila] = React.useState(null);

  const [loading, setLoading] = React.useState(true);
  const [error, setError] = React.useState(null);
  React.useEffect(() => {
    // Funkcija za dohvaćanje podataka
    const fetchData = async () => {
      try {
        let data;
        const response = await fetch("http://localhost:5089/api/vozila", {
          method: "GET", // or 'PUT'
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(data),
        });
        if (!response.ok) {
          throw new Error("Network response was not ok");
        }
        const result = await response.json();
        console.log("Success:", result);

        // setVozila(result);
        setVozila(result); // Postavi podatke
      } catch (error) {
        setError(error); // Postavi grešku
      } finally {
        setLoading(false); // Postavi učitavanje na false
      }
    };

    fetchData();
  }, []); // Prazan niz znači da će se useEffect pokrenuti samo jednom, nakon montiranja

  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error: {error.message}</p>;

  return (
    <div>
      {vozila.map((vozilo) => (
        <KarticaVozilo vozilo={vozilo} key={vozilo.idVozilo}></KarticaVozilo>
      ))}
    </div>
  );
};

export default SvaVozila;
