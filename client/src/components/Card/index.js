import React from "react";
import moment from "moment";
import "moment/locale/tr";

function Card({ title, time, body, image, link }) {
  const date = moment.unix(time).fromNow();

  return (
    <div className="card my-3">
      {image ? <img src={image} className="card-img-top" alt="..." /> : null}
      <div className="card-body">
        <p className="card-title">
          @{title} · <span className="text-muted">{date}</span>
        </p>
        <p className="card-text">{body}</p>
        <a href={link} className="btn btn-primary">
          Go somewhere
        </a>
      </div>
    </div>
  );
}

export default Card;
