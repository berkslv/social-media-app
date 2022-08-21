import Logo from "../assets/logo-light.svg";


const Login = () => {
  return (
    <section class="hero has-background-link-light is-fullheight">
      <div class="hero-body">
        <div class="container">
          <div class="columns is-centered">
            <div class="column is-5-tablet is-4-desktop is-3-widescreen">
              <div class="column is-three-quarters mx-auto">
                <img src={Logo} alt="Logo" />
              </div>
              <form action="" class="box">
                <div class="field">
                  <label for="" class="label">
                    Email
                  </label>
                  <div class="control">
                    <input
                      type="email"
                      placeholder="e.g. berkslv@gmail.com"
                      class="input"
                      required
                    />
                  </div>
                </div>
                <div class="field">
                  <label for="" class="label">
                    Parola
                  </label>
                  <div class="control">
                    <input
                      type="password"
                      placeholder="*******"
                      class="input"
                      required
                    />
                  </div>
                </div>
                <div class="field mt-3">
                  <button class="button is-success is-fullwidth">
                    Giriş yap
                  </button>
                </div>
                <div class="field mt-3">
                  <button class="button has-background-success-light has-text-success is-fullwidth">
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
