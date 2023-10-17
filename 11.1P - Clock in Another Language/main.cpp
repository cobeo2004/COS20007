#include <iostream>
#include <string>
#include <sstream>
#include <iomanip>
#include <thread>
#include <chrono>

namespace CounterClass
{
    class Counter
    {
    private:
        int _count;
        std::string _name;

    public:
        Counter(const std::string &name, int count) : _name(name), _count(count)
        {
        }

        void Increment()
        {
            _count++;
        }

        void Reset()
        {
            _count = 0;
        }

        std::string GetName() const
        {
            return _name;
        }

        void SetName(std::string value)
        {
            _name = value;
        }

        int GetTicks() const
        {
            return _count;
        }
    };
};

namespace ClockClass
{
    class Clock
    {
    private:
        CounterClass::Counter *_second;
        CounterClass::Counter *_minute;
        CounterClass::Counter *_hour;

    public:
        Clock()
        {
            _second = new CounterClass::Counter("second", 0);
            _minute = new CounterClass::Counter("minute", 0);
            _hour = new CounterClass::Counter("hour", 0);
        }

        void Tick()
        {
            _second->Increment();
            if (_second->GetTicks() > 59)
            {
                _minute->Increment();
                _second->Reset();
                if (_minute->GetTicks() > 59)
                {
                    _hour->Increment();
                    _minute->Reset();
                    if (_hour->GetTicks() > 23)
                    {
                        this->Reset();
                    }
                }
            }
        }

        void Reset()
        {
            _second->Reset();
            _minute->Reset();
            _hour->Reset();
        }

        void SetTime(const std::string &time)
        {
            int parsedTime[3];
            std::istringstream ss(time);
            std::string timeToken;
            int index = 0;

            while (std::getline(ss, timeToken, ':') && index < 3)
            {
                parsedTime[index] = std::stoi(timeToken);
                index++;
            }

            delete _hour;
            delete _minute;
            delete _second;

            _hour = new CounterClass::Counter("hour", parsedTime[0]);
            _minute = new CounterClass::Counter("minute", parsedTime[1]);
            _second = new CounterClass::Counter("second", parsedTime[2]);
        }

        std::string GetCurrentTime() const
        {
            std::ostringstream oss;
            oss << std::setw(2) << std::setfill('0') << _hour->GetTicks() << ":" << std::setw(2) << std::setfill('0') << _minute->GetTicks() << ":" << std::setw(2) << std::setfill('0') << _second->GetTicks();
            return oss.str();
        }

        ~Clock()
        {
            delete _hour;
            delete _minute;
            delete _second;
        }
    };
};

int main(int argc, char **argv)
{
    ClockClass::Clock *c = new ClockClass::Clock();

    for (int i = 0; i <= 86400; i++)
    {
        std::cout << c->GetCurrentTime() << std::endl;
        c->Tick();
    }
    return 0;
}
