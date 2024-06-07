import React, { useState, useEffect } from "react";

// Kreiraj komponentu TabSaloni
const TabSaloni = () => {
  // Definiši state za podatke, učitavanje i greške
  const [saloni, setSaloni] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  // Koristi useEffect za dohvaćanje podataka prilikom montiranja komponente
  useEffect(() => {
    // Funkcija za dohvaćanje podataka
    const fetchData = async () => {
      try {
        let data;
        const response = await fetch("http://localhost:5089/api/saloni", {
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
        // await response.json();
        setSaloni(result); // Postavi podatke
      } catch (error) {
        setError(error); // Postavi grešku
      } finally {
        setLoading(false); // Postavi učitavanje na false
      }
    };

    fetchData();
  }, []); // Prazan niz znači da će se useEffect pokrenuti samo jednom, nakon montiranja

  // Prikaži učitavanje, grešku ili podatke
  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error: {error.message}</p>;

  return (
    <div>
      <h1>Saloni</h1>
      <table className="table">
        <thead>
          <tr>
            <td>Rbr.</td>
            <td>Naziv</td>
          </tr>
        </thead>
        <tbody>
          {saloni.map((salon, index) => (
            <tr key={salon.idSalona}>
              <td>{index + 1}</td>
              <td>{salon.nazivSalona}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default TabSaloni;
