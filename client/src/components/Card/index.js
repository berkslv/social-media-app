import React from "react";

function Card({ cardHeader, cardTitle, cardText, cardButtons, cardFooter }) {
  return (
    <div className="card">
      {cardHeader && <div className="card-header">{cardHeader}</div>}
      <div className="card-body">
        {cardTitle && <h5 className="card-title">{cardTitle}</h5>}
        {cardText && <p className="card-text">{cardText}</p>}
        {cardButtons && { cardButtons }}
      </div>
      {cardFooter && <div className="card-footer">{cardFooter}</div>}
    </div>
  );
}

export default Card;
