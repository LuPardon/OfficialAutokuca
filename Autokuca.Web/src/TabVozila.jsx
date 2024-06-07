import React, { useState, useEffect } from "react";

// Kreiraj komponentu TabVozila
const TabVozila = () => {
  // Definiši state za podatke, učitavanje i greške
  const [vozila, setVozila] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  // Koristi useEffect za dohvaćanje podataka prilikom montiranja komponente
  useEffect(() => {
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
        // await response.json();
        setVozila(result); // Postavi podatke
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
      <h1>Vozila</h1>
      <table className="table">
        <thead>
          <tr>
            <td>Rbr.</td>
            <td>Registracija</td>
            <td>Tip vozila</td>
            <td>Proizvođač</td>
            <td>Godina proizvodnje</td>
            <td>Oznaka</td>
            <td>Snaga motora</td>
          </tr>
        </thead>
        <tbody>
          {vozila.map((vozilo, index) => (
            <tr key={vozilo.idVozilo}>
              <td>{index + 1}</td>
              <td>{vozilo.sifraVozila}</td>
              <td>{vozilo.tipVozila}</td>
              <td>{vozilo.proizvodac}</td>
              <td>{vozilo.godProizvodnje}</td>
              <td>{vozilo.oznakaVozila}</td>
              <td>{vozilo.snagaMotora}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default TabVozila;
