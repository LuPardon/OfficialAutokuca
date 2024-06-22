import React from "react";

export default function Pocetna() {
  return (
    <div
      className="flex justify-center items-center"
      style={{ height: "100vh", display: "flex" }}
    >
      <iframe
        src="https://www.google.com/maps/d/embed?mid=18_BF7vSwbmR8eriblFAm57WUO65zb_U&ehbc=2E312F"
        width="1040"
        height="680"
        style={{ display: "block", margin: "auto", border: "none" }}
      ></iframe>
    </div>
  );
}
