import React from "react";
import { useParams } from "react-router-dom";
import { Card } from "primereact/card";

const StranicaVozilo = () => {
  const [vozilo, setVozilo] = React.useState(null);
  const [loading, setLoading] = React.useState(true);
  const [error, setError] = React.useState(null);

  let { id } = useParams();

  React.useEffect(() => {
    // Funkcija za dohvaćanje podataka
    const fetchData = async () => {
      try {
        let data;
        const response = await fetch("http://localhost:5089/api/vozila/" + id, {
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
        setVozilo(result); // Postavi podatke
      } catch (error) {
        setError(error); // Postavi grešku
      } finally {
        setLoading(false); // Postavi učitavanje na false
      }
    };

    fetchData();
  }, []);

  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error: {error.message}</p>;
  return (
    <div className="card">
      <Card title="Simple Card">
        <p className="m-0">
          {vozilo.tipVozila} {vozilo.proizvodac} {vozilo.modelVozila} i ostali
          opis
        </p>
      </Card>
    </div>
  );
};

export default StranicaVozilo;
