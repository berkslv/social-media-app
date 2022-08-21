import Logo from "../assets/logo-light.svg";


const Login = () => {
  return (
    <section className="hero has-background-link-light is-fullheight">
      <div className="hero-body">
        <div className="container">
          <div className="columns is-centered">
            <div className="column is-5-tablet is-4-desktop is-3-widescreen">
              <div className="column is-three-quarters mx-auto">
                <img src={Logo} alt="Logo" />
              </div>
              <form action="" className="box">
                <div className="field">
                  <label for="" className="label">
                    Email
                  </label>
                  <div className="control">
                    <input
                      type="email"
                      placeholder="e.g. berkslv@gmail.com"
                      className="input"
                      required
                    />
                  </div>
                </div>
                <div className="field">
                  <label for="" className="label">
                    Parola
                  </label>
                  <div className="control">
                    <input
                      type="password"
                      placeholder="*******"
                      className="input"
                      required
                    />
                  </div>
                </div>
                <div className="field mt-3">
                  <button className="button is-success is-fullwidth">
                    Giriş yap
                  </button>
                </div>
                <div className="field mt-3">
                  <button className="button has-background-success-light has-text-success is-fullwidth">
                    Giriş yapmadan devam et
                  </button>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
    </section>
  );
};

export default Login;
